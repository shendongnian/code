    public class FooBarService : System.Web.Services.WebService
    {
        [WebMethod]
        public MyXElement Foo(string bar)
        {
            return null;
        }
    }
    public class MyXElement : XElement
    {
        public MyXElement()
            : base(XName.Get("default")) { }
    }
