    public class LoadSessionTradingPrtNrVM
    {
        public LoadSession()
        {
            this.AcceptedTransactions = new HashSet<AcceptedTransaction>();
            this.RejectedTransactions = new HashSet<RejectedTransaction>();
        }
    
        public int LoadSessionId { get; set; }
        public int Import { get; set; }
        public string FilePath { get; set; }
        public string TradingPartnerBatchId { get; set; }
        public System.DateTime Started { get; set; }
        public int RecordsOnFile { get; set; }
        public int RecordsAfterGroupFilter { get; set; }
        public int RecordsAccepted { get; set; }
        public int RecordsRejected { get; set; }
        public System.DateTime Completed { get; set; }
        public bool Success { get; set; }
        public Nullable<int> Extract { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<AcceptedTransaction> AcceptedTransactions { get; set; }
        public virtual Extract Extract1 { get; set; }
        public virtual Import Import1 { get; set; }
        public virtual ICollection<RejectedTransaction> RejectedTransactions { get; set; }
    }
