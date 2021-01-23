    using Microsoft.VisualStudio.TestTools.UnitTesting;
    namespace MyTests
    {
      [TestClass]
      public sealed class TestAssemblyInitialize
      {
        [AssemblyInitialize]
        public static void Initialize(TestContext context)
        {
          ...
        }
      }
    }
