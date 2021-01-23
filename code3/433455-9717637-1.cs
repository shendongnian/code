    [Table("tblInvestment")]
    class Investment
    {
        [Key]
        public string InvestmentId { get; set; }
        [ForeignKey("PrimaryPerformance")]
        public string PrimaryPerformanceId { get; set; }            
        public virtual Performance PrimaryPerformance { get; set; }
        
        public virtual ICollection<Performance> Performances { get; set; }
    }
    
    [Table("tblPerformance")]
    class Performance
    {
        [Key]
        public string PerformanceId { get; set; }
        public virtual Investment Investment { get; set; }
    }
