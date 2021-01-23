    public class TestClass
    {
        public enum ABigEnum
        {
            A,
            B,
            C,
            D
        }
        public IEnumerable TestValues
        {
            get
            {
                yield return new TestCaseData(ABigEnum.A, false).SetName("Assert A");
                yield return new TestCaseData(ABigEnum.B, false).SetName("Assert B");
                yield return new TestCaseData(ABigEnum.C, false).SetName("Assert C");
                yield return new TestCaseData(ABigEnum.D, true).SetName("Assert D");
            }
        }
        [Theory]
        [TestCaseSource(typeof(TestClass), "TestValues")]
        public void Test(ABigEnum enumValue, bool assertValue)
        {
            //generate someValue based upon enumValue    
            Assert.That(enumValue, Is.EqualTo(assertValue), "an amazing assertion message");
        }
 
    }
