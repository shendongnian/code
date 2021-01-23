    public abstract class TestBase {
        private string itemType;
        protected TestBase(string itemType) {
            this.itemType = itemType;
        }
    }
    public class TestClass1 : TestBase {
        public TestClass1() : base(
           ConfigurationManager.AppSettings["TestClass1.ItemType"])
        {}
    }
