    // Define this once in a class and re-use for every connection..
    string myConnString = "user id=MyUserName;" +
           "password=MyPassword;server=myServer;" +
           "database=myDatabase; " +
           "connection timeout=30";
        using (SqlConnection mySqlConnection = new SqlConnection(myConnString))
        {
            using (SqlCommand mySQLCommand = new SqlCommand("SELECT Field1, Field2 FROM TableName", mySqlConnection) { CommandType = CommandType.Text})
            {
                try
                {
                    mySqlConnection.Open();
                    using (SqlDataReader rdr = mySQLCommand.ExecuteReader())
                    {
                        this.comboBox1.Items.Add(rdr["Field1"].ToString() + ": " + rdr["Field2"].ToString());
                    }
                }
                catch (Excecption e)
                {
                  // Deal with it as you wish
                }
                mySqlConnection.Close();
             }
         }
