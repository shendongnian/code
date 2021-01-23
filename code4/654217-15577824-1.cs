    public class SiteHandler : ISiteHandler
    {
         public string InsertDataToDatabase(Handler siteInfo)
         {
              try
              {
                  // Open Database Connection, Run Commands, Some additional Checks.
              }
              catch(SqlException exception)
              {
                 SqlExceptionHelper errorCompare = new SqlExceptionHelper(exception);
                 return errorCompare.ToString();
              }
         }
    }
