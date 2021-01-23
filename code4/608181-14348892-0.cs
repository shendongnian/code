    public class SomeObject
    {
       private Dictionary<int, String> myGames;
       public SomeObject()
       {
          myGames = new Dictionary<int, string>();
       }
       public AddGame(int id, string desc)
       {
           myGames.Add(id,desc);
       }
       public string FindGameById(int id)
       {
          if(myGames.ContainsKey(id))
          {
             return myGames[id];
          }
          return null;
       }
    }
