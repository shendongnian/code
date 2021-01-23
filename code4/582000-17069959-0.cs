    public sealed class BrowserIE
    {
        
        static readonly IE _Instance = new IE();
        
        static BrowserIE()
        {}
        
        BrowserIE()
        { }
        public static IE Instance
        {
            get { return _Instance; }
        }
    }
