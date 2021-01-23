    public class ItemManager
    {
        private static volatile ItemManager _instance;
        private static object syncRoot = new Object();
        private ObservableCollection<ItemBase> _registeredItems = new ObservableCollection<ItemBase>();
        private ItemManager()
        {
        }
        public ItemManager Instance
        {
            get
            {
                 if (instance == null) 
                 {
                     lock (syncRoot) 
                     {
                         if (instance == null) 
                             instance = new ItemManager();
                     }
                 } 
                 return instance;
            }
        }
        
        public void RegisterItem(ItemBase item)
        {
            _registeredItems.Add(item);
            // Do some stuff here, subscribe events, etc.
        }
        public void UnregisterItem(item)
        {
            // Do some stuff here, unregister events, etc.
            _registeredItems.Remove(item)
        }
    }
