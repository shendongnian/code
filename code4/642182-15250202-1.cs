    public static class BasicClass
    {
        static MyConfiguration _myConfig;
    
        static BasicClass()
        {
           // read configuration from file
           _myConfig = ReadConfigFromConfigFile("somefile.conf");
        }
       
        private static MyConfiguration ReadConfigFromConfigFile(string file)
        {
           using (StreamReader reader = new StreamReader(file);
           {
             ...
           }
        }
    }
