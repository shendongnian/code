    public class Sale
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    
        [Key, Column(TypeName = "varchar"), MaxLength(50)]
        public string TrNo { get; set; }
    
        public DateTime Date { get; set; }
        public int CustomerID { get; set; }
    
        public ObservableCollection<SaleDetail> SaleDetails { get; set; }
    }
