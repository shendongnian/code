    public class Project
    {
        XElement self;
        public Project(FileInfo file)
        {
            self = XElement.Load(file.FullName);
        }
    
        public ItemGroup[] ItemGroup
        {
            get
            {
                return _ItemGroup
                    ?? (_ItemGroup = self.GetEnumerable("ItemGroup", x => new ItemGroup(x)).ToArray());
            }
        }
        ItemGroup[] _ItemGroup;
    }
    
    public class ItemGroup
    {
        XElement self;
        public ItemGroup(XElement self)
        {
            this.self = self;
        }
    
        public XElementCollection Build
        {
            get
            {
                return _Build
                    ?? (_Build = new XElementCollection(self, "Build",
                             (a, b) => a.Get("Include", string.Empty) ==
                                       b.Get("Include", string.Empty),
                             false));
            }
        }
        XElementCollection _Build;
    
        public XElementCollection NotInBuild
        {
            get
            {
                return _NotInBuild
                    ?? (_NotInBuild = new XElementCollection(self, "NotInBuild",
                             (a, b) => a.Get("Include", string.Empty) ==
                                       b.Get("Include", string.Empty),
                             false));
            }
        }
        XElementCollection _NotInBuild;
    }
