    class StoreOrder : IOrder<StoreOrderItem>
    {
        public int Id { get; set; }
    }
    
    class StoreOrderItem : IOrderItem
    {       
        public IOrder<IOrderItem> Parent { get; set; } // This doesn't satisfy the interface
    }
