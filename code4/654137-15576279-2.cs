    public class ItemListWrapper
    {
        public List<Item> Contents;
    
        public void Add(Item item){ item.List = this; this.Contents.Add(item); }
    }
    
    public class Item
    {
       ItemListWrapper List;
       void DoStuffAndRemove() { this.List.Contents.Remove(this); }
    }
