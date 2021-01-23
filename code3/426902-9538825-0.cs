    public class PurchaseOrder
    {
        XElement self;
        public PurchaseOrder(XElement self) { this.self = self; }
    
        public int Number
        {
             get { return self.Get<int>("po-number", 0); }
        }
    
        public POLine[] Lines
        {
             get { return _Lines ?? (_Lines = self.GetEnumerable("po-line", xe => new POLine(xe)).ToArray()); }
        }
        POLine[] _Lines;
    }
    
    public class POLine
    {
        XElement self;
        public POLine(XElement self) { this.self = self; }
    
        public string ItemName
        {
            get { self.Get("po-line-header/item-name", string.Empty); }
        }
    }
