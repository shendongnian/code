    public string getWhileLoopData()
    {
     string htmlStr = "";
    SqlConnection thisConnection = new SqlConnection(dbConnection);
            SqlCommand thisCommand = thisConnection.CreateCommand();
            thisCommand.CommandText = "SELECT * from Test";
            thisConnection.Open();
            SqlDataReader reader = thisCommand.ExecuteReader();
    
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string Name = reader.GetString(1);
                string Pass = reader.GetString(2);
                htmlStr +="<tr><td>"+id+"</td><td>"+Name+"</td><td>"+Pass+"</td></tr>"                   
            }
    
            thisConnection.Close();
            return htmlStr;
    }
