    public class Order
    {
        XElement self;
        public Order(XElement order)
        {
            self = order;
        }
    
        public string OrderNumber 
        { 
            // if your xml looks like <Order OrderNumber="somenumber" />
            get { return (string)(self.Attribute("OrderNumber ") ?? "some default value/null"); } 
            // but if it looks like: <Order><OrderNumber>somenumber</OrderNumber></order>
            // get { return (string)(self.Element("OrderNumber ") ?? "some default value/null"); }
        }
    }
    
