    public class YourMainViewModel
    {
      public int ID { set;get;}
      
      public int SelectedItemId { set;get;}
      public IEnumerable<Item> Items();
      //other properties
    }
    
    public class Item
    {
      public int Id { set;get;}
      public string Status { set;get;}
    }
