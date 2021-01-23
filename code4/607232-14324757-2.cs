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
    var lib  = new DocLib<Item>();
    lib.Item = new Item { Title="ABC", spriteCssClass="DEF" };
    lib.Items = new List<DocLib<Item>> { 
      new DocLib<Item>{ Item = new Item {Title="ABC2", spriteCssClass="DEF2"} },
      new DocLib<Item>{ Item = new Item {Title="ABC3", spriteCssClass="DEF3"} }
    };
    //Get the values
    var root = lib.Item;
    var subItems = lib.Items.Select(i=>i.Item);
