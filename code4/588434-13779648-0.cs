    using System;
    public class MySQLHandler
    {
       private static MySQLHandler instance;
    
       private MySQLHandler() {}
    
       public static MySQLHandler Instance
       {
          get 
          {
             if (instance == null)
             {
                instance = new MySQLHandler();
             }
             return instance;
          }
       }
    }
