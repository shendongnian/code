    class Item<T> {
      public T ItemId { get; set; }
    }
    
    interface IItemRepository<T> {
      Item<T> GetItem(T itemId);
    }
