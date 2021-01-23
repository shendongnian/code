    public class XFile
    {
        XElement self;
        public XFile(string file)
        {
            self = XElement.Load(file);
        }
        public AttributeValue[] AttributeValues
        {
            get
            {
                return _AttributeValues ??
                    (_AttributeValues = self.Elements("AttributeValue").Select(x => new AttributeValue(x)).ToArray());
            }
        }
        AttributeValue[] _AttributeValues;
        public SteamStuff[] SteamStuffs
        {
            get
            {
                return _SteamStuffs ??
                    (_SteamStuffs = self.Elements("SteamStuff").Select(x => new SteamStuff(x)).ToArray());
            }
        }
        SteamStuff[] _SteamStuffs;
    }
    public class SteamStuff
    {
        XElement self;
    
        public SteamStuff(XElement self) { this.self = self; }
    
        public XElement Element { get { return self; } }
    
        public string ID
        {
            get { return self.Get("ID", string.Empty); }
        }
    
        public string Label
        {
            get { return self.Get("Label", string.Empty); }
        }
    }
    
    public class AttributeValue
    {
        XElement self;
    
        public AttributeValue(XElement self) { this.self = self; }
    
        public XElement Element { get { return self; } }
    
        public string ID
        {
            get { return self.Get("ID", string.Empty); }
        }
    }
    XFile xfile = new XFile("test.xml");
    SteamStuff[] pirates = xfile.SteamStuffs
                                .Where(steam => steam.Label == "pirate")
                                .ToArray();  
    
    AttributeValue[] associated = xfile.AttributeValues
                                       .Where(av => pirates.Any(pirate => pirate.ID == av.ID))
                                       .ToArray();
    
    // write to new file
    XElement fragments = new XElement("fragments");
    foreach(SteamStuff steamStuff in pirates)
        fragments.Add(steamStuff.Element);
    foreach(AttributeValue value in associated)
        fragments.Add(value.Element);
    fragments.Save("fragment_file.xml");
