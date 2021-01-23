    [TestClass]
    public class PhoneAreaAttributeTest
    {
        public PhoneAreaAttribute PhoneAreaAttribute { get; set; }
        [TestInitialize]
        public void PhoneAreaAttributeTest_TestInitialise()
        {
            PhoneAreaAttribute = new PhoneAreaAttribute();
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void PhoneAreaAttributeTest_IsValid_ThrowsInvalidCastException()
        {
            object objectToTest = new object();
            PhoneAreaAttribute.IsValid(objectToTest);
        }
        [TestMethod]
        public void PhoneAreaAttributeTest_IsValid_NullOrEmpty_True()
        {
            string nullToTest = null;
            string emptoToTest = string.Empty;
            var nullTestResult = PhoneAreaAttribute.IsValid(nullToTest);
            var emptyTestResult = PhoneAreaAttribute.IsValid(emptoToTest);
            Assert.IsTrue(nullTestResult, "Null Test should return true.");
            Assert.IsTrue(emptyTestResult, "Empty Test should return true.");
        }
    }
