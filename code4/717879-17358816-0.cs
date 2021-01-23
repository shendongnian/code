    public class ReceiptContainer
    {
        public ReceiptCr receipt_cr;
        public ReceiptDr receipt_dr;
        public PaymentDr payment_dr;
    
        public ReceiptContainer() 
        {
            receipt_cr = new ReceiptCr();
            receipt_dr = new ReceiptDr();
            payment_dr = new PaymentDr();
        }
    
        public class ReceiptCr
        {
            public String[] VchNo { get; set; }
            public String[] VoucherName { get; set; }
            public DateTime[] VchDate { get; set; }
            public String[] LedgerName { get; set; }
            public String[] UnderGroup { get; set; }
            public Decimal[] NetAmount { get; set; }
            public String[] AgnstRefNumber { get; set; }
            public Decimal[] AgnstReferenceAmount { get; set; }
            public String[] CostCentreName { get; set; }
            public String[] CostCategory { get; set; }
            public String[] Status { get; set; }
            public ReceiptCr() { }
        }
        public class ReceiptDr
        {
            public String[] VchNo { get; set; }
            public String[] VoucherName { get; set; }
            public DateTime[] VchDate { get; set; }
            public String[] CashOrBankLedger { get; set; }
            public String[] UnderGroup { get; set; }
            public Decimal[] Amount { get; set; }
            public String[] TransactionType { get; set; }
            public String[] InstrumentNo { get; set; }
            public DateTime[] BankDate { get; set; }
            public String[] BankName { get; set; }
            public String[] BankBranch { get; set; }
            public String[] Narration { get; set; }
            public ReceiptDr() { }
        }
        public class PaymentDr
        {
            public String[] VchNo { get; set; }
            public String[] VoucherName { get; set; }
            public DateTime[] VchDate { get; set; }
            public String[] LedgerName { get; set; }
            public String[] UnderGroup { get; set; }
            public Decimal[] NetAmount { get; set; }
            public String[] AgnstRefNumber { get; set; }
            public Decimal[] AgnstReferenceAmount { get; set; }
            public String[] CostCentreName { get; set; }
            public String[] CostCategory { get; set; }
            public String[] Status { get; set; }
            public PaymentDr() { }
        }
    }
