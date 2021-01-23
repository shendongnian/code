    public string ChargePointText { get; set; }
        
    public class FirstTable 
    {
        [Key]
        public int UserID { get; set; }
    
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]      
        public string Summ 
        {
            get { return /* do your sum here */ }
            private set { /* needed for EF */ }
        }
    }
