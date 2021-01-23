    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Reflection;
    namespace TestProject2
    {
        public interface IMyInterface
        {
            [Description("Test Attribute")]
            void Member();
        }
        [TestClass]
        public class Class1 : IMyInterface
        {
            public void Member()
            {
            }
            [TestMethod]
            public void TestAttributeInheritance()
            {
                MethodInfo info = typeof(Class1).GetMethod("Member");
                Assert.AreEqual(1, info.GetCustomAttributes(typeof(DescriptionAttribute), true).Length);
            }
        }
    }
