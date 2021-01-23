    public class Core
    {
        private Dig dig;
        public Core()
        {
            dig = new Dig();
        }
        public void startTest()
        {
            dig.resolver.DnsServer = "10.10.10.10";
            ...
        }
    }
