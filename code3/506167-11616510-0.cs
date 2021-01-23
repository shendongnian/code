    public sealed class PurchaseOrderStatus
    {
        public static readonly PurchaseOrderStatus Open =
            new PurchaseOrderStatus("Open");
        public static readonly PurchaseOrderStatus Received =
            new PurchaseOrderStatus("Received");
        private readonly string text;
        public string Text { get { return value; } }
        private PurchaseOrderStatus(string text)
        {
            this.text = text;
        }
    }
