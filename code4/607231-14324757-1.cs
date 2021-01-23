    public class DocLib<T>
    {
       public T Item { get; set; }
       public IEnumerable<DocLib<T>> Items { get; set; }
    }
    
    public class Item
    {
       public string Title { get; set; }
       public string spriteCssClass { get; set; }
    }
    
    //Usage
    //Set up a root item, and some sub-items
    var lib = new DocLib<Item>();
    lib.Item = new Item { Title="ABC", spriteCssClass="DEF" };
    lib.Items = new List<DocLib<Item>> { 
     new Item {Title="ABC2", spriceCssClass="DEF2",
     new Item {Title="ABC3", spriceCssClass="DEF3"
    };
    //Get the values
    var root = lib.Item;
    var subItems = lib.Items.Select(i=>i.Item);
