    public class Item<T>
    {
        public T ItemId { get; set; }
    }
    public class StringItem<T> : Item<T>
    {
    }
    public interface IItemRepository<T>
    {
        Item<T> GetItem(T itemId);
    }
    public class StringItemRepository<T> : IItemRepository<T>
    {
        public Item<T> GetItem(T itemId)
        {
            throw new NotImplementedException();
        }
    }
