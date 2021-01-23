    public class Loader
    {
        ItemsToLoad item;
        public Loader(ItemsToLoad item) {
          this.item = item;
        }
    
        public Execute()
        {
           // do things using item like item.add();
        }
    }
    
    interface ItemsToLoad
    {
        void add();
    }
    
    class ItemsToLoad1: ItemsToLoad
    {
        void add(){
            // implementation
        }
    }
    
    class ItemsToLoad2: ItemsToLoad
    {
        void add(){
            // implementation
        }
    }
    
