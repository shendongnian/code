    public class Basket
    {
      private IList<string> Contents;
      public Basket()
      {
         Contents = new Contents(); 
      }
    
      public void Add(string Item)
      {
         Contents.Add(Item);
      }
      public void Empty()
      {
        Contents.Clear(); 
      }
    }
