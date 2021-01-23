    public static class QuotePreview
    {
        public static ObservableCollection<PurchasableItem> LineItems { get; private set; }
        static QuotePreview()
        {
            LineItems = new ObservableCollection<PurchasableItem>();
        }
        public static void Add(List<PurchasableItems> selections)
        {
            foreach (var selection in selections)
            {
                LineItems.Add(selection);
            }
        }
        public static void Clear()
        {
            LineItems.Clear();
        }
    }
    public class QuoteTab : TabItem
    {
        public ObservableCollection<PurchasableItem> PreviewItems { get; private set; }
        public QuoteTab()
        {          
            Initialize()
            PreviewItems = QuotePreview.LineItems;
            DataGrid.ItemSource = PreviewItems
        }
    }
