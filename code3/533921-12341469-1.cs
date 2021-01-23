    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ExampleLibrary;
    namespace HomeTest
    {
        [TestClass]
        public class TestInventoryTypeCase
        {
            [TestMethod]
            public void TestInventoryTypeClass()
            {
                InventoryType.InventorySelect select = new InventoryType.InventorySelect();
                select.InventoryTypes = "Collection";
                Assert.IsTrue(select.Validate());
            }
        }
    }
