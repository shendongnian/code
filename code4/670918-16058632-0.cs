    public abstract class TestBase
    {
        protected abstract string ItemType {get;}
    }
    public class TestClass1 : TestBase
    {
        protected override string ItemType 
        {
            get { return ConfigurationManager.AppSettings["TestClass1.ItemType"];}
        }
    }
