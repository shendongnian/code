    public abstract class TestBase
    {
        protected string itemType;    // can now become 'readonly`
    
        protected TestBase(string keyName)
        {
           itemType = ConfigurationManager.AppSettings[keyName];
        }
    }
    
    public class TestClass1 : TestBase
    {
        public TestClass1() : base("TestClass1.ItemType")
        {
            //itemType = ConfigurationManager.AppSettings["TestClass1.ItemType"];
        }
    }
