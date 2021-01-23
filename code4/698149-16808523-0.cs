    public abstract class MyItemsBase
    {
        /* Define everything here */
    }
    [Table(Name = "MyItems")]
    public class TableMyItems : MyItemsBase { }
    [Table(Name = "ItemsFiltered")]
    public class ViewMyItems : MyItemsBase { }
