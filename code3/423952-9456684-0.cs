    public class Core
    {
        private static Dig dig = new Dig();
        public void startTest()
        {
            dig.resolver.DnsServer = "10.10.10.10";
            ...
        }
    }
