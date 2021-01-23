    public abstract class BaseClass
    {
        protected readonly Dictionary<string, object> Values = new Dictionary<string, object>();
    }
    public class ChildClass : BaseClass
    {
        public ChildClass()
        {
            Values["UserID"] = 123;
            Values["Foo"] = "Bar";
        }
    }
