    [TestFixture]
    public class my_test
    {
        private bool my_test(string url, string[] fields, int someVal)
        {
            // test setup
            return DidTestCompleteOk;
        }
    
        [Test]
        public void TestURL1()
        {
            Assert.IsTrue( my_test("someurl1", new[] { "param1", "param2" }, 15));
        }
    
        [Test]
        public void TestURL2()
        {
            Assert.IsTrue( my_test("someurl2", new[] { "param3" }, 15) );
        }
    }
