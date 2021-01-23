    internal class Program
    {
        private static void Main(string[] args)
        {
            var api = new API();
            api.Begin()
               .Login("username", "password")
               .Send("someuri");
            Console.ReadLine();
        }
    }
    public class API
    {
        public XElement Begin()
        {
            // this just creates the wrapper
            return new XElement("Envelope", new XElement("Body"));
        }
    }
    public static class APIExtension
    {
        public static XElement Login(this XElement request, string username, string password)
        {
            // you can have some fancy logic here
            var un = new XElement("USERNAME", username);
            var pw = new XElement("PASSWORD", password);
            var li = new XElement("Login", un, pw);
            request.Element("Body").Add(li);
            return request;
        }
        public static void Send(this XElement request, string uri)
        {
            // do something here like write to an http stream or something
            var xml = request.ToString();
            Console.WriteLine(xml);
        }
    }
