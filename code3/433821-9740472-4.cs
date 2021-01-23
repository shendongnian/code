    interface IOrder<TOrder, TOrderItem> 
        where TOrderItem : IOrderItem<TOrder>
    {
        IList<TOrderItem> Items { get; set; }
    }
    
    interface IOrderItem<TOrder>
    {
        TOrder Parent { get; set; }
    }
