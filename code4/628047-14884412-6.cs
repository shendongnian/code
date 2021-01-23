    class Cart
    {
        List<CartEntry> entries;
    
        public void RemoveEntry(CartEntry entry)
        {
            entry.Item.QuantityInCarts -= entry.Quantity;
            entries.Remove(entry);
        }
    
        public void RemoveExpiredEntries()
        {
          foreach (var entry in entries.Where(x => x.IsExpired()).ToArray())
          {
              RemoveEntry(entry);
          }
        }
    }
