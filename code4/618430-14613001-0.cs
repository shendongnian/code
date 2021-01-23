    public class Sale
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Key]
        public string TrNo { get; set; }
        public DateTime Date { get; set; }
        public int CustomerID { get; set; }
    
        public ObservableCollection<SaleDetail> SaleDetails { get; set; }
    }
