    public class ProductViewModel
    {
      public int ID { set;get;}
      public string Name { set;get;}
    }
    
    public class OrderViewModel
    {
      public int OrderNumber { set;get;}
      public List<ProductViewModel> Products { set;get;}
      public int SelectedProductId { set;get;}    
    }
