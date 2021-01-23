    public class NodeConfiguration
    {
        XElement self;
        public NodeConfiguration(XElement self) { this.self = self; }
    
        public IEnumerable<string> DBChanges
        { 
            get 
            { 
                return self.GetEnumerable("DBChange", x => x.Get("value", string.Empty));
            }
        }
    }
