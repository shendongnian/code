    public class ErrorMessage
    {
        public DateTime ErrorDate { get; set; }
        public string ErrorText { get; set; }
        public int DexRowId { get; set; }
    }
    public class Transaction
    {
        public string TransactionType { get; set; }
        public string Processed { get; set; }
        public DateTime UpdateDate { get; set; }
        public int DexRowID { get; set; }
        public string Text { get; set; }
    }
    public class Result
    {
        public List<ErrorMessage> errorMessageList { get; set; }
        public List<Transaction> transactionList { get; set; }
        
    }
