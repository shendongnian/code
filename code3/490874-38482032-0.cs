    public class Product
    {
      public Product(
          TenantId tenantId,
          ProductId productId,
          ProductOwnerId productOwnerId,
          string name,
          string description)
      {
        State = new ProductState();
        State.ProductKey = tenantId.Id + ":" + productId.Id;
        State.ProductOwnerId = productOwnerId;
        State.Name = name;
        State.Description = description;
        State.BacklogItems = new List<ProductBacklogItem>();
      }
      internal Product(ProductState state)
      {
        State = state;
      }
      //...
      private readonly ProductState State;
    }
    public class ProductState
    {
      [Key]
      public string ProductKey { get; set; }
      public ProductOwnerId ProductOwnerId { get; set; }
      public string Name { get; set; }
      public string Description { get; set; }
      public List<ProductBacklogItemState> BacklogItems { get; set; }
      ...
    }
