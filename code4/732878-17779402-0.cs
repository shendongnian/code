    public static class Global
    {
        private string s_sSomeProperty;
    
        static Globals ()
        {
            s_sSomeProperty = ...;
            ...
        }
        
        public static string SomeProperty
        {
            get
            {
                return ( s_sSomeProperty );
            }
            set
            {
                s_sSomeProperty = value;
            }
        }
        
        ...
    }
