    #region Usings
    using MyHelpers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Linq;
    #endregion
    
    namespace UnitTests
    {
        [TestClass]
        public class StringJoinExtensionsFixture
        {
            [DataTestMethod]
            [DataRow("", "", null, null)]
            [DataRow("1", "1", null, null)]
            [DataRow("1 and 2", "1", "2", null)]
            [DataRow("1, 2 and 3", "1", "2", "3")]
            [DataRow(", 2 and 3", "", "2", "3")]
            public void ReturnsCorrectResults(string expectedResult, 
                 string string1, string string2, string string3)
            {
                var input = new[] { string1, string2, string3 }
                    .Where(r => r != null);
                string actualResult = input.JoinAnd(", ", " and ");
                Assert.AreEqual(expectedResult, actualResult);
            }
    
            [TestMethod]
            public void ThrowsIfArgumentNulls()
            {
                string[] values = default;
                Assert.ThrowsException<ArgumentNullException>(() =>
                     StringJoinExtensions.JoinAnd(values, ", ", " and "));
    
                Assert.ThrowsException<ArgumentNullException>(() =>
                   StringJoinExtensions.JoinAnd(new[] { "1", "2" }, null, 
                      " and "));
            }
    
            [TestMethod]
            public void LastSeparatorCanBeNull()
            {
                Assert.AreEqual("1, 2", new[] { "1", "2" }
                   .JoinAnd(", ", null), 
                       "lastSeparator is set to null explicitly");
                Assert.AreEqual("1, 2", new[] { "1", "2" }
                   .JoinAnd(", "), 
                       "lastSeparator argument is not specified");
            }
    
            [TestMethod]
            public void SeparatorsCanBeEmpty()
            {
                Assert.AreEqual("1,2", StringJoinExtensions.JoinAnd(
                    new[] { "1", "2" }, "", ","), "separator is empty");
                Assert.AreEqual("12", StringJoinExtensions.JoinAnd(
                     new[] { "1", "2" }, ",", ""), "last separator is empty");
                Assert.AreEqual("12", StringJoinExtensions.JoinAnd(
                     new[] { "1", "2" }, "", ""), "both separators are empty");
            }
    
            [TestMethod]
            public void ValuesCanBeNullOrEmpty()
            {
                Assert.AreEqual("-2", StringJoinExtensions.JoinAnd(
                   new[] { "", "2" }, "+", "-"), "1st value is empty");
                Assert.AreEqual("1-", StringJoinExtensions.JoinAnd(
                     new[] { "1", "" }, "+", "-"), "2nd value is empty");
                Assert.AreEqual("1+2-", StringJoinExtensions.JoinAnd(
                    new[] { "1", "2", "" }, "+", "-"), "3rd value is empty");
    
                Assert.AreEqual("-2", StringJoinExtensions.JoinAnd(
                 new[] { null, "2" }, "+", "-"), "1st value is null");
                Assert.AreEqual("1-", StringJoinExtensions.JoinAnd(
                 new[] { "1", null }, "+", "-"), "2nd value is null");
                Assert.AreEqual("1+2-", StringJoinExtensions.JoinAnd(
                 new[] { "1", "2", null }, "+", "-"), "3rd value is null");
            }
        }
    }
