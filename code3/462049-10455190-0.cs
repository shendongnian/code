      namespace WebApplication1.Classes
      {
        public class Connections
        {
          public static string DBConn = 
              ConfigurationManager.ConnectionStrings["HomeDB"].ConnectionString;
        }
      }
