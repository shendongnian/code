        public class MySingleton
        {
                private static MySingleton _mInstance;
        
                public static MySingleton Instance
                {
                    get { return _mInstance ?? (_mInstance = new MySingleton()); }
                }
            
            /// <summary>
            /// You can send values through this string.
            /// </summary>
            public string SomeString { get; set; }
        }
