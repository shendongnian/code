    [Table("tblPerformance")]
    class Performance
    {
        [Key]
        public string PerformanceId { get; set; }
        public string InvestmentId { get; set; }
        [InverseProperty("Performances")]
        public virtual Investment Investment { get; set; }
    }
