    class StoreOrder: IOrder<StoreOrder, StoreOrderItem>
    {
        public DateTime Date { get; set; }
        public IList<StoreOrderItem> Items { get; set; }
    }
    
    class StoreOrderItem : IOrderItem<StoreOrder>
    {
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public StoreOrder Parent { get; set; }
    }
