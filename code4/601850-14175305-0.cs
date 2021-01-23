    public class MyConfiguration{
         private static string myConnString;
         
         public static string MyConnectionString
         {
             get{
                   if(myConnString == null){
                        myConnString = ConfigurationManager.ConnectionStrings["MyTeamScoresDB"].ConnectionString;
                   }
                   return myConnString;
             }
         } 
    }
