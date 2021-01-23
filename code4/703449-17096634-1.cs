    using ClassLibrary7;
    using ClassLibrary7.Fakes;
    using Microsoft.QualityTools.Testing.Fakes;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    namespace Test
    {
        [TestClass]
        public class UnitTest1
        {
            [TestMethod]
            public void TestMethod1()
            {
                using (ShimsContext.Create())
                {
                    var child = new Child();
    
                    var shim = new ShimParent(child);
                    shim.Method = () => "Detour";
    
                    string result = child.Method();
    
                    Assert.IsFalse(result.Contains("Parent"));
                    Assert.IsTrue(result.Contains("Detour"));
                    Assert.IsTrue(result.Contains("Child"));
                }
            }
        }
    }
