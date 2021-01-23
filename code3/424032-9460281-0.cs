    public class Duel
    {
      public string User1 {get; protected set;}
      public string User2 {get; protected set;}
      public Duel(string user1, string user2)
      {
        User1 = user1;
        User2 = user2;
      }
    
      public HashSet<string> GetUserSet()
      {
        HashSet<string> result = new HashSet<string>();
        result.Add(this.User1);
        result.Add(this.User2);
        return result;
      }
    
      //TODO ... more impl
    }
