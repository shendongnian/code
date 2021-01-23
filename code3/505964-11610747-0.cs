    public class ReadFileClass
    {
        //Can be replaced with auto property
        public Dictionary<string, string> Settings
        {
            Get{return Settings}
            Set{Settings = value}
        }
        public ReadFileClass()
        {
            //In this constructor you run the code to populate the dictionary
            ReadFile();
        }
        //Method to populate dictionary
        private void ReadFile()
        {
             //Do Something
             //Settings = result of doing something
        }
    }
    //First class to run in your application
    public class UseFile
    {
        private ReadFileClass readFile;
 
        public UseFile()
        {
            //This instance can now be used elsewhere and passed around
            readFile = new ReadFileClass();
        }
 
        private void DoSomething()
        {
            //function that takes a readfileclass as a parameter can use without making a new instance internally
            otherfunction(reafFileClass);
        }
    }
