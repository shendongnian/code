    public class ProductSale
    {  
       public IEnumerable<SelectListItem> Dealers{ get; set; }
       public int SelectedDealer { get; set; }
      
       public IEnumerable<SelectListItem> SubDealers{ get; set; }
       public int SelectedSubDealer { get; set; }
    
       //Other Existing properties also.
      public ProductSale()
      {
         Dealers=new List<SelectListItem>();
         SubDealers=new List<SelectListItem>();
      }
    }
