    public class Configuration
    {
        //just some made up config settings
        public string Name {get;set;}
        public int Id {get;set;}
        public int XDimension {get;set;}
        public int YDimension {get;set;}
    }
    class Program
    {
        static Configuration Config;
        static void Main(string[] args)
        {
            Config = ReadConfig();
        }
        private static Configuration ReadConfig()
        {
            var config = new Configuration();
            //read entire XML and set properties on the config object
            return config;
        }
    }
