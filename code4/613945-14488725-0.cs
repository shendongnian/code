    public class Contract {
        [Key]
        public int ContractID { get; set; }
        public double PricePerUnit { get; set; }
        public int Unit { get; set; }
        public int Currency { get; set; }
    
        public virtual Client Client { get; set; }
    
        public virtual Company Company { get; set; }
    
        public virtual Article Article { get; set; }
    }
