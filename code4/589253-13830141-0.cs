    [Editor(typeof(OrderListEditor), typeof(UITypeEditor))]
    class OrderList
	{
		public OrderList() { Orders = new List<order>(); }
		public List<order> Orders { get; }
	}
