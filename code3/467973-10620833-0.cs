    class Item<T> {
      public ItemId { get; set; }
    }
    
    interface IItemRepository<T> {
      Item<T> GetItem(T itemId);
    }
