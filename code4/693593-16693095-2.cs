    public class ProductMap : ClassMap<Product>
    {
      public ProductMap()
      {
        Id(x => x.Id);
        Map(x => x.Name);
        References(x => x.Description).Columns("Id");
      }
    }
