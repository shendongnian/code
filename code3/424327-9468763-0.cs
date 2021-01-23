        /// <summary>
        /// Singleton class
        /// </summary>
        public class Test
        {
            private static Test _instance;
    
            public static Test Instance
            {
                get
                {
                    if (_instance == null)
                    {
                        _instance = new Test();
                    }
    
                    return _instance;
                }
            }
    
            public string Data {get;set;}
        }
    
        /// <summary>
        /// Form A
        /// </summary>
        public class FormA()
        {
            public FormA()
            {
                //Put some data in the 'Data' property of the singleton
                Test.Instance.Data = "value";
            }
        }
    
        /// <summary>
        /// Form B
        /// </summary>
        public class FormB()
        {
            public FormB()
            {
                //Get the data form the 'Data' property of the singleton
                string value = Test.Instance.Data;
            }
        }
