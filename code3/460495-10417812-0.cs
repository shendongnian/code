    public class MyReceiptViewModel
    {
        public List<ReceiptItem> ReceiptItems { get; set; }
    }
    public class ReceiptItem
    {
        public string Content { get; set; }
        public bool IsHighlighted { get; set; }
    }
