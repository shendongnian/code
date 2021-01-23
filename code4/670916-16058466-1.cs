    public abstract class TestBase {
        protected string ItemType {get;set;}
        // or:
        // public string ItemType {get;protected set;}
    }
    public class TestClass1 : TestBase {
        public TestClass1() {
           ItemType = ConfigurationManager.AppSettings["TestClass1.ItemType"];
        }
    }
