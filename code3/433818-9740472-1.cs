    class StoreOrderItem : IOrderItem
    {
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public StoreOrder Parent { get; set; } // note: original implementation
        
        IOrder<IOrderItem> IOrderItem.Parent {  // explicit interface implementation
            get { return (IOrder<IOrderItem>)this.Parent; }
            set { this.Parent = (StoreOrder)value; }
        }
    }
