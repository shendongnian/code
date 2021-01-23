    public class Parser{
    
     private TextReader _reader; //Get set in Constructor
     private List<Item> _items;    
    
     public IEnumerable<Item> Items{
      get{
       return _items ?? (_items = LoadItems().ToList());
      }
     }
    
     private IEnumerable<Item> LoadItems(){
      while(_reader.Peek() >= 0){
       yield return new Item(_reader.ReadLine()); //Actually it's a little different
      }
     }
    }
