    public class <>f__AnonymousType0<T1,T2,T3>
    {
        private readonly T1 accountingDocumentNbr;
        private readonly T2 glCompanyCode;
        private readonly T3 documentFiscalYearNbr;
        public T1 AccountingDocumentNbr
        {
            get { return accountingDocumentNbr; }
        }
        public T2 GLCompanyCode
        {
            get { return glCompanyCode; }
        }
        public T3 DocumentFiscalYearNbr
        {
            get { return documentFiscalYearNbr; }
        }
        public <>f__AnonymousType0(T1 accountingDocumentNbr, T2 glCompanyCode, T3 documentFiscalYearNbr)
        {
            this.accountingDocumentNbr = accountingDocumentNbr;
            this.glCompanyCode = glCompanyCode;
            this.documentFiscalYearNbr = documentFiscalYearNbr;
        }
        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append("{ AccountingDocumentNbr = ");
            builder.Append(AccountingDocumentNbr);
            builder.Append(", GLCompanyCode = ");
            builder.Append(GLCompanyCode);
            builder.Append(", DocumentFiscalYearNbr = ");
            builder.Append(DocumentFiscalYearNbr);
            builder.Append(" }");
            return builder.ToString();
        }
        public override bool Equals(object value)
        {
            var type = value as <>f__AnonymousType0<T1,T2,T3>;
            return (type != null) && EqualityComparer<T1>.Default.Equals(type.AccountingDocumentNbr, AccountingDocumentNbr) && EqualityComparer<T2>.Default.Equals(type.GLCompanyCode, GLCompanyCode) && EqualityComparer<T3>.Default.Equals(type.DocumentFiscalYearNbr, DocumentFiscalYearNbr);
        }
        public override int GetHashCode()
        {
            int num = 0x7a2f0b42;
            num = (-1521134295*num) + EqualityComparer<T1>.Default.GetHashCode(AccountingDocumentNbr);
            num = (-1521134295*num) + EqualityComparer<T2>.Default.GetHashCode(GLCompanyCode);
            return (-1521134295*num) + EqualityComparer<T3>.Default.GetHashCode(DocumentFiscalYearNbr);
        }
    }
