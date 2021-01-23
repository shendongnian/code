    using NUnit.Framework;
    
    namespace UnitTests
    {
        [TestFixture]
        public class UnitTests
        {
            [Test]
            public void CurrentContextTest()
            {
                Assert.IsNotNull(TestContext.CurrentContext);
                Assert.IsNotNull(TestContext.CurrentContext.TestDirectory);
                Assert.IsNotNull(TestContext.CurrentContext.WorkDirectory);
            }
        }
    }
