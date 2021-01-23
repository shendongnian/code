    private void GetData()
    {
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
                    //do whatever to the data
                    ListItem item = new ListItem(Convert.ToString(dataReader["TutorialName"])); 
                    lst.Items.Add(item);
                 }
               }
       }
    }
