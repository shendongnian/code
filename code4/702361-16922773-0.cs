    [Table("HOUSE_TABLE")]
    public class house {
     //some properties
     public int HouseID {get;set;}
     
     public ICollection<Sale> Sales { get; set; }
    
     public datatime LastSaleDate 
     {
       get 
       {
         return this.Sales.OrderByDescending(s => s.SaleDate).First();
       }
     }
    }
 
