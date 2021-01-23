    public class Customer
        {
            .
            .            
    
            public string CountryID { get; set; }
            [ForeignKey("CountryID")]
            public virtual Country Country { get; set; }
            .
            .
    
        }
