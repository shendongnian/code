    public class Order
    {
        XElement self;
        public Order(XElement order)
        {
            self = order;
        }
        public XElement Element { get { return self; } }
    
        public string OrderNumber 
        { 
            // if your xml looks like <Order OrderNumber="somenumber" />
            get { return (string)(self.Attribute("OrderNumber") ?? (object)"some default value/null"); } 
            // but if it looks like: <Order><OrderNumber>somenumber</OrderNumber></Order>
            // get { return (string)(self.Element("OrderNumber") ?? (object)"some default value/null"); }
        }
    }
    
