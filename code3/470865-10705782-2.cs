    internal class Program
    {
        private static void Main(string[] args)
        {
            new API()
                .Begin()
                .Login("username", "password")
                .Send("someuri");
            Console.ReadLine();
        }
    }
    public class API
    {
        public static readonly XNamespace XMLNS = "urn:hello:world";
        public static readonly XName XN_ENVELOPE = XMLNS + "Envelope";
        public static readonly XName XN_BODY = XMLNS + "Body";
        public XDocument Begin()
        {
            // this just creates the wrapper
            return new XDocument(new XDeclaration("1.0", Encoding.UTF8.EncodingName, "yes")
                                    , new XElement(XN_ENVELOPE
                                        , new XElement(XN_BODY)));
        }
    }
    public static class APIExtensions
    {
        public static void Send(this XDocument request, string uri)
        {
            if (request.Root.Name != API.XN_ENVELOPE)
                throw new Exception("This is not a request");
            // do something here like write to an http stream or something
            var xml = request.ToString();
            Console.WriteLine(xml);
        }
    }
    public static class APILoginExtensions
    {
        public static readonly XName XN_LOGIN = API.XMLNS + "Login";
        public static readonly XName XN_USERNAME = API.XMLNS + "USERNAME";
        public static readonly XName XN_PASSWORD = API.XMLNS + "PASSWORD";
        public static XDocument Login(this XDocument request, string username, string password)
        {
            if (request.Root.Name != API.XN_ENVELOPE)
                throw new Exception("This is not a request");
            // you can have some fancy logic here
            var un = new XElement(XN_USERNAME, username);
            var pw = new XElement(XN_PASSWORD, password);
            var li = new XElement(XN_LOGIN, un, pw);
            request.Root.Element(API.XN_BODY).Add(li);
            return request;
        }
    }
