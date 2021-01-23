    public class Core
    {
        private static Dig dig = new Dig();
        public static void startTest()
        {
            dig.resolver.DnsServer = "10.10.10.10";
            ...
        }
    }
