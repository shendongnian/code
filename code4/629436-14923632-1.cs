    public class Config
    {
        public string Param1{get;private set;}
        public int Param2(get;private set;}
    
        public Config(string param1, int param2)
        {
            Param1=param1;
            Param2=param2;
        }
    
        // take a string[] if you prefer to use Environment.GetCommandLineArgs
        public Config ParseCommandLine(string commandLine)
        {
            string param1=...;
            int param2=...;
    
            return new Config(param1, param2);
        }
    
        public Config ParseCommandLine()
        {
           return ParseCommandLine(Environment.CommandLine);
        }
    }
