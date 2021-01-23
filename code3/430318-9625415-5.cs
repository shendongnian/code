    public class Device
    {
        const bool ELEMENT = false;
        const bool ATTRIBUTE = true;
    
        XElement self;
        public Device(XElement self) { this.self = self; }
    
        public string CustomName 
        { 
            get { return self.Get("customname", string.Empty); }
            set { self.Set("customname", value, ELEMENT); }
        }
        public string Name { get { return self.Get("name", string.Empty); } }
        public string Ip { get { return self.Get("ip", "0.0.0.0"); } }
        public int Port { get { return self.Get("port", 0); } }
    
        public Source[] Sources
        {
            get { return _Sources ?? (_Sources = self.GetEnumerable("sources/source", xsource => new Source(xsource)).ToArray()); }
        }
        Source[] _Sources;
    
        public class Source
        {
            XElement self;
            public Source(XElement self) { this.self = self; }
    
            public string Code { get { return self.Get("code", string.Empty); } }
            public string Name { get { return self.Get("name", string.Empty); } }
            public bool Hidden { get { return self.Get("hidden", false); } }
        }
    }
