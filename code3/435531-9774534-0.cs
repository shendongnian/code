    public interface IOrder<out T> where T : IOrderItem
    {
        IEnumerator<T> Items { get; }
    }
    
    public interface IDistro<out T> : IOrder<T> where T : IOrderItem
    {
    
    }
