    [TestFixture]
    public class TestGetBookInfo
    {
        object[] TestData =
        {
            new TestCaseData(new BookMarketStub()), // "good" case
            new TestCaseData(null).Throws(typeof(YourException)) // "bad" exceptional case
        };
    
        [Test]
        [TestCaseSource("TestData")]
        public void TestGetBookInfo(IBookMarket bookinfo)
        {
            new BookInfoProvider().GetBookInfo(bookinfo);
            Assert.Pass("all ok"); // this is not necessary
        }
    }
