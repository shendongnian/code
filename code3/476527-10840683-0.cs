    [System.ComponentModel.Description("aaa")]
    class Page1 { }
    [System.ComponentModel.Description("bbb")]
    class Page2 { }
    [TestClass]
    public class Tests
    {
        private static string GetDescription(string typeName)
        {
            var type = System.Reflection.Assembly.GetExecutingAssembly()
                .GetTypes().Single(t => t.Name == typeName);
            return type.GetCustomAttributes(false)
                .OfType<System.ComponentModel.DescriptionAttribute>()
                .Single().Description;
        }
        [TestMethod]
        public void MyTestMethod()
        {
            Assert.AreEqual("aaa", GetDescription("Page1"));
            Assert.AreEqual("bbb", GetDescription("Page2"));
        }
    }
