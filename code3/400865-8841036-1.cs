    public sealed class Order : ModelBase
    {
        public Order() { }
        public string OrderNumber { get; private set; }
        protected override void DoClear()
        {
            OrderNumber = string.Empty;
        }
        protected override void DoRead(XPathNavigator xmlNav)
        {
            DoClear();
            XPathNavigator node;
            node = xmlNav.SelectSingleNode("OrderNumber");
            if (node != null)
                OrderNumber = node.InnerXml;
            // implement other properties here
        }
    }
