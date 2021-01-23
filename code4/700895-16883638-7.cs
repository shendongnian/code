    class Bank : IBank
    {
        private ISpecification<IBank> spec;
        private LedgerCode code;
        public Bank(ISepcification<IBank> spec)
        {
            this.code = code;
            this.spec = spec;
        }
        public LedgerCode LedgerCode { get; set; }
        public bool IsValid 
        { 
            get
            {
                return spec.IsSatisfiedBy(this);
            }
        } 
    }
