    using Microsoft.QualityTools.Testing.Fakes;
    using MyLib;
    
    namespace UnitTestProject1
    {
        [TestClass]
        public class UnitTest1
        {
            [TestMethod]
            public void TestMethod1()
            {
                using (ShimsContext.Create())
                {
                    MyLib.Fakes.ShimFruit.ConstructorString = delegate(Fruit f, string s)
                    {
                        var shimFruit = new MyLib.Fakes.ShimFruit(f);
                        shimFruit.ToString = () =>
                        {
                            return "Orange";
                        };
                    };
                    AppleTree tree = new AppleTree();
                    string expected = "Orange";
                    Assert.AreEqual(expected, tree.GetApple());
                }
            }
        }
    }
