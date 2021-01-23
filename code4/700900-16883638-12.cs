    class LedgerCodeSpec : ISpecification<IBank>
    {
        private LedgerCode code;
        public LedgerCodeSpecification(LedgerCode code)
        {
            this.code = code
        }
        public override bool IsSatisfiedBy(IBank obj)
        {
            return obj.LedgerCode == code;
        }
    }
