     [TestClass]
        public class GrammarTest
        {
            [TestMethod]
            public void TestThatResultContainsAnAnd()
            {
                var test = new List<String> { "Manchester", "Chester", "Bolton" };
    
                var oxbridgeAnd = test.OxbridgeAnd();
               
                Assert.IsTrue( oxbridgeAnd.Contains(", and"));
            }
        }
