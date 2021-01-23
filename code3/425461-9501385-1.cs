    public class SomeController : ApiController
    {
        [WebInvoke(UriTemplate = "{itemSource}/Items"), Method="GET"]
        public SomeValue GetItems(CustomParam parameter) { ... }
    
        [WebInvoke(UriTemplate = "{itemSource}/Items/{parent}", Method = "GET")]
        public SomeValue GetChildItems(CustomParam parameter, SomeObject parent) { ... }
    }
