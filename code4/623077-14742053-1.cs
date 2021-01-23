    public class ProductViewModel 
    {
       public int Id { get; set; }
       public string Name { get; set; }
       public decimal Price { get; set; }
       public string CategoryName { get; set; }
    }
    
    public class ProductDetailViewModel : ProductViewModel 
    {
       public int Stocke { get; set; }
       public string Obs { get; set; }
       public IEnumerable<ProductMovViewModel> Inventory 
       /* other properties */
    }
    
    public class ProductMovViewModel 
    {
       public int Id { get; set; } 
       public DateTime Date { get; set;
       public int Amout { get; set; }
    }
