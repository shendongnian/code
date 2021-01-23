    private List<string> GetData()
    {
       List<string> lst = new List<string>();
       //The object that will physically connect to the database
       using(SqlConnection cnx = new SqlConnection("<your connection string>")
       {
                //The SQL you want to execute
               SqlCommand cmd = new SqlCommand("SELECT * FROM ASPNET_TUTORIALS");
               //Open the connection to the database
               cnx.Open();
               //execute your command
               using (IDataReader dataReader = cnx.ExecuteReader(cmd))
               {
                 //Loop through your results
                 while(dataReader.Read())
                 {
                    lst.Add(Convert.ToString(dataReader["TutorialName"]));
                 }
               }
       }
       return lst;
    }
 
