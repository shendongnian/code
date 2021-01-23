     public static class Data
     {
         public static SqlConnection CreateConnection()
         {
            System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder();
                builder["Initial Catalog"] = "Upload";
                builder["Data Source"] = "base";
                builder["integrated Security"] = true;
                string connexionString = builder.ConnectionString;
                var connexion = new SqlConnection(connexionString);
                connexion.Open(); 
                return connexion; 
        
         }
     }
