﻿using System;
using System.Globalization;
using System.Text;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FinanceBetterTrading.WebRequest;
using HtmlAgilityPack;
using System.Xml;

namespace FinanceBetterTrading.UITest.WebRequestTests
{
    [TestClass]
    public class RequstTWSE
    {

        [TestMethod]
        public void TestGetStockPrice()
        {
            RequestTWSE requestTwse = new RequestTWSE();
            var result = requestTwse.GetStockPrice("3514");
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestGetStockPriceIsNull()
        {
            RequestTWSE requestTwse = new RequestTWSE();
            var result = requestTwse.GetStockPrice("0000");

            var expect = 0;
            var actual = result.Count;
            Assert.AreEqual(expect, actual);
        }


        [TestMethod]
        public void TestPostdata()
        {
            RequestServer requestServer = new RequestServer();
            StringBuilder postData = new StringBuilder();
            postData.Append(HttpUtility.UrlEncode(String.Format("report1={0}&", "day")));
            postData.Append(HttpUtility.UrlEncode(String.Format("input_date={0}&", "103/12/05")));
            postData.Append(String.Format("mSubmit={0}&", "%ACd%B8%DF"));
            postData.Append(HttpUtility.UrlEncode(String.Format("yr={0}", "2014")));
            postData.Append(HttpUtility.UrlEncode(String.Format("w_date={0}&", "20141201")));
            postData.Append(HttpUtility.UrlEncode(String.Format("m_date={0}", "20141201")));
            string url = "http://www.twse.com.tw/ch/trading/fund/BFI82U/BFI82U.php";
            var result = requestServer.GetPostHtmlData(url, postData.ToString(), "/html[1]");
            Assert.IsNotNull(result);
        }
    }
}