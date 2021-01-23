    [Serializable]
    public class ShoppingCartItem
    {
      public ShoppingCartItem(guid key, decimal price, int quantity)
      {
        this.Key = key;
        this.Price = price;
        this.Quantity = quantity;
      }
      public Guid Key { get; private set; }
      public Decimal Price { get; private set; }
      public int Quantity { get; set; }
    }
    [Serializable]
    public class ShoppingCart
    {
      public ShoppingCart()
      {
        this.Clear();
      }
      public ICollection<ShoppingCartItem> Items { get; private set; }
      public int ItemCount 
      {
        get { return this.Items.Sum(i => i.Quantity); }
      }
      public decimal Subtotal
      {
        get { return this.Items.Sum(i => i.Quantity * i.Price); }
      }
      public void Clear()
      {
        this.Items = new List<ShoppingCartItem>();
      }
    }
