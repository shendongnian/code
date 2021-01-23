    public class ItemListWrapper
    {
        public List<Item> Contents;
    
        public void DoStuffAndRemove(Item item)
        { 
            if(this.Contents.Contains(item))
            {
                item.DoStuff();
                this.Contents.Remove(item);
            }
        }
    }
    
    public class Item
    {
       void DoStuff() { ... }
    }
