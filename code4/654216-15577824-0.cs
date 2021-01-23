    public class SqlExceptionHelper
    {
        public SqlExceptionHelper(SqlException sqlException)
        {
            // Do Nothing.
        }
    
        public static string GetSqlDescription(SqlException sqlException)
        {
            switch (sqlException.Number)
            {
                 case 21:
                     return "Fatal Error Occurred: Error Code 21.";
                 case 53:
                     return "Error in Establishing a Database Connection: 53.";
                 default
                     return ("Unexpected Error: " + sqlException.Message.ToString());
             }
         }
    }
