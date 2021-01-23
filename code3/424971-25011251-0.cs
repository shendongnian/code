    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            var settings = new NameValueCollection {{"User", "Otuyh"}};
            var classUnderTest = new ClassUnderTest(settings);
            // Act
            classUnderTest.MethodUnderTest();
            // Assert something...
        }
    }
    public class ClassUnderTest
    {
        private readonly NameValueCollection _settings;
        public ClassUnderTest(NameValueCollection settings)
        {
            _settings = settings;
        }
        public void MethodUnderTest()
        {
            // get the User from Settings
            string user = _settings["User"];
            // log
            Trace.TraceInformation("User = \"{0}\"", user);
            // do something else...
        }
    }
