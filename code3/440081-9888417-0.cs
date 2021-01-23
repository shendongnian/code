    public class MySingleton
            {
                private static Classes.MySingleton _mInstance;
    
                public static Classes.MySingleton Instance
                {
                    get { return _mInstance ?? (_mInstance = new Classes.MySingleton()); }
                }
    
                private string _cbbadress;
    
                /// <summary>
                /// cbbAdress.
                /// </summary>
                public string cbbadress
                {
                    get { return _cbbadress; }
                    set { _cbbadress = value; }
                }
            }
