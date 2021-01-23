    [Table("tblInvestment")]
    class Investment
    {
        [Key]
        public string InvestmentId { get; set; }
        public string PrimaryPerformanceId { get; set; }
    
        [ForeignKey("PerformanceId")]
        public virtual Performance PrimaryPerformance { get; set; }
        
        public virtual ICollection<Performance> Performances { get; set; }
    }
    
    [Table("tblPerformance")]
    class Performance
    {
        [Key]
        public string PerformanceId { get; set; }
        [ForeignKey("InvestmentId")]
        public virtual Investment Investment { get; set; }
    }
