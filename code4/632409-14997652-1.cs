    [TextFixture]
    public class Tests {
    
        [Test]
        public void Test_Length0_ReturnsNothing() {
            string result = Generate(0);
            
            Assert.IsTrue(string.IsNullOrEmpty(result));
        }
    }
