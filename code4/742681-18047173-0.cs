    public sealed class Client
    {
       private static readonly Client instance = new Client();
       
       private Client(){}
    
       public static Client Instance
       {
          get 
          {
             return instance; 
          }
       }
       public int  X {get;set;}
    }
