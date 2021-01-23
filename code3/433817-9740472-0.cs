    void Main()
    {
        var so = new StoreOrder { Date = DateTime.Now };
        var item = new StoreOrderItem {
                Parent = so,
                ItemName = "Hand soap",
                ItemPrice = 2.50m };
        so.Items = new [] { item };
        
        Console.WriteLine(item.Parent.Date);
        Console.WriteLine(so.Items.First().ItemName);
    }
    interface IOrder<TOrder,TOrderItem> 
        where TOrderItem : IOrderItem<TOrder,TOrderItem>
        where TOrder : IOrder<TOrder,TOrderItem>
    {
        IList<TOrderItem> Items { get; set; }
    }
    
    interface IOrderItem<TOrder,TOrderItem> 
        where TOrderItem : IOrderItem<TOrder,TOrderItem>
        where TOrder : IOrder<TOrder,TOrderItem>
    {
        TOrder Parent { get; set; }
    }
    
    class StoreOrder: IOrder<StoreOrder, StoreOrderItem>
    {
        public DateTime Date { get; set; }
        public IList<StoreOrderItem> Items { get; set; }
    }
    
    class StoreOrderItem : IOrderItem<StoreOrder, StoreOrderItem>
    {
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public StoreOrder Parent { get; set; }
    }
