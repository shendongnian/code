    public class Item
    {
       public int Id;
       public int OrderId;
       public virtual Order { get; set; } 
    }
