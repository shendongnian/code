	class StoreOrder : IOrder<StoreOrderItem>
	{
		// interface members
		public IList<StoreOrderItem> Items { get; set; }
		// own members
		public int Id { get; set; }
	}
	class StoreOrderItem : IOrderItem
	{
		public IOrder<IOrderItem> Parent { get; set; }
	}
