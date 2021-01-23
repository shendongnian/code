    public class Cart
    {
        public ObservableCollection<ShoppingItem> Items { get; private set; }
    
        public Client()
        {
             Items = new ObservableCollection<ShoppingItem>();
        }
    }
