         public class DBOperator 
         {
           //Only static methods, so no public constructor
           private DBOperator()
           {
           }
           // static constructor          
           static DBOperator()
           {
              // do initialization stuff
            } 
            // have static functions to operate on your database
            public static int ExecuteNonQuery(string storedProc, params object[]         parameters)
            {}
         }
