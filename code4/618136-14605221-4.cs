    public class TransactionInfo
    {
        public long TransactionId { get; set; }
        public string BuyerName { get; set; }
        public string SellerName { get; set; }
        public TransactionInfo(long transactionId, string buyerName, string sellerName)
        {
            TransactionId = transactionId;
            BuyerName = buyerName;
            SellerName = sellerName;
        }
    }
