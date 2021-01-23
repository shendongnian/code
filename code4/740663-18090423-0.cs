    interface ICustomObject
    {
        public string RequiredProperty { get; }
        
        public void RequiredMethod();
    }
    public class CustomObjectA : ICustomObject
    {
        public string RequiredProperty
        {
            get
            {
                return "I'm CustomObjectA";
            }
        }
        
        public void RequiredMethod()
        {
            // do anything
        }
    }
    public class CustomObjectB : ICustomObject
    {
        public string RequiredProperty
        {
            get
            {
                return "I'm CustomObjectB";
            }
        }
        
        public void RequiredMethod()
        {
            // do anything
        }
    }
    public void AcceptsAllCustomObjects(List<ICustomObject> Cookies)
    {
        Console.WriteLine(Cookies[0].RequiredProperty);
    }
