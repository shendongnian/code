    [TestFixture]
    public class TestGetBookInfo
    {
        [Test]
        [ExpectedException(
            ExpectedException = typeof(YourException),
            ExpectedMessage = "Your detailed message",
            MatchType = MessageMatch.Contains)]
        public void TestGetBookInfoException()
        {
            new BookInfoProvider().GetBookInfo(null);
        }
    }
