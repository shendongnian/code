    public class Client
    {
        public ObservableCollection<ShoppingItem> Items { get; private set; }
    
        public Client()
        {
             Items = new ObservableCollection<ShoppingItem>();
        }
    }
