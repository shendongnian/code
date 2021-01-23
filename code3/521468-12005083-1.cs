    [TestFixture]
    public class TestGetBookInfo
    {
        [Test]
        public void TestGetBookInfo()
        {
            Assert.That(
                () => new BookInfoProvider().GetBookInfo(null),
                    Throws.InstanceOf<YourException>()
                        .And.Message.Contains("Your detailed message"));
        }
    }
