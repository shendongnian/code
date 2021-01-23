    public class TMEngine
    {
       private TMEngine() {}
    
       private static TMEngine instance;    
       public static TMEngine Instance
       {
          get 
          {
             if (instance == null)             
                instance = new TMEngine();             
             return instance;
          }
       }
       public string GetSomeStringData()
       {
           ...
       }
    }
