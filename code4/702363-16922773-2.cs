    [Table("HOUSE_TABLE")]
    public class house 
    {
        //some properties
        public int HouseID {get;set;}
     
        public virtual ICollection<Sale> Sales { get; set; }
    
        public DateTime LastSaleDate 
        {
            get 
            {
                return this.Sales.OrderByDescending(s => s.SaleDate).First();
            }
        }
    }
 
