    public class ProductSale
    {  
       public IEnumerable<SelectListItem> Products{ get; set; }
       public int SelectedProduct { get; set; }
      
       public IEnumerable<SelectListItem> SaleNumbers{ get; set; }
       public int SelectedSaleNumber { get; set; }
    
       //Other Existing properties also.
      public ProductSale()
      {
         Products=new List<SelectListItem>();
         SaleNumbers=new List<SelectListItem>();
      }
    }
