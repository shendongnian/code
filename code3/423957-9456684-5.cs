    public class Core
    {
        private Dig dig;
        public Core()
        {
            dig = new Dig();
        }
        public static void startTest()
        {
            Core core = new Core();
            core.dig.resolver.DnsServer = "10.10.10.10";
            ...
        }
    }
