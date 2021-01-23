    public class XFile
    {
        XElement self;
    
        public XFile(string file)
        {
            self = XElement.Load(file);
        }
    
        public XNamespace Namespace
        {
            get { return _Namespace ?? (_Namespace = self.GetDefaultNamespace()); }
        }
        XNamespace _Namespace;
    
        public AttributeValue[] AttributeValues
        {
            get
            {
                return _AttributeValues ??
                    (_AttributeValues = self.Elements(Namespace + "AttributeValue").Select(x => new AttributeValue(this, x)).ToArray());
            }
        }
        AttributeValue[] _AttributeValues;
    
        public SteamStuff[] SteamStuffs
        {
            get
            {
                return _SteamStuffs ??
                    (_SteamStuffs = self.Elements(Namespace + "SteamStuff").Select(x => new SteamStuff(this, x)).ToArray());
            }
        }
        SteamStuff[] _SteamStuffs;
    }
    
    public class SteamStuff
    {
        XElement self;
        XFile parent;
    
        public SteamStuff(XFile parent, XElement self)
        {
            this.parent = parent;
            this.self = self;
        }
    
        public XElement Element { get { return self; } }
    
        public string ID
        {
            get { return self.Get(Namespace + "ID", string.Empty); }
        }
    
        public string Label
        {
            get { return self.Get(Namespace + "Label", string.Empty); }
        }
    
        public XNamespace Namespace { get { return parent.Namespace; } }
    }
    
    public class AttributeValue
    {
        XElement self;
        XFile parent;
    
        public AttributeValue(XFile parent, XElement self)
        {
            this.parent = parent;
            this.self = self;
        }
    
        public XElement Element { get { return self; } }
    
        public XNamespace Namespace { get { return parent.Namespace; } }
    
        public string ObjectID
        {
            get { return self.Get(Namespace + "ObjectID", string.Empty); }
        }
    }
    XFile xfile = new XFile("test.xml");
    SteamStuff[] pirates = xfile.SteamStuffs
                                .Where(steam => steam.Label == "pirate")
                                .ToArray();  
    
    AttributeValue[] associated = xfile.AttributeValues
                                       .Where(av => pirates.Any(pirate => pirate.ID == av.ObjectID))
                                       .ToArray();
    
    // write to new file
    XElement fragments = new XElement(xfile.Namespace + "fragments");
    foreach(SteamStuff steamStuff in pirates)
        fragments.Add(steamStuff.Element);
    foreach(AttributeValue value in associated)
        fragments.Add(value.Element);
    fragments.Save("fragment_file.xml");
