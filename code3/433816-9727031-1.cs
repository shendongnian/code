	class StoreOrder : IOrder<StoreOrderItem>
	{
		public IList<StoreOrderItem> Items { get; set; }
	}
	class StoreOrderItem: IOrderItem<StoreOrderItem>
	{
		public IOrder<StoreOrderItem> Parent { get; set; }
	}
