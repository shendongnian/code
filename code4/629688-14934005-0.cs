    public static bool saveToDb(string name1, string nam2, DateTime dat)
    {
      bool ok = false;
      string sqlQuery = "INSERT INTO NumbersTable VALUES (@name1, @nam2, @dat)";
      //This is the sql query we will use and by placing the @ symbol in front of words
      //Will establish them as variables and placeholders for information in an sql command
      //Next we create the sql command
      SqlCommand cmd = new SqlCommand(sqlQuery, con);
      //Here we will insert the correct values into the placeholders via the commands
      //parameters
      cmd.Parameters.AddWithValue("name1", name1);
      //This tells it to replace "@name1" with the value of name1
      cmd.Parameters.AddWithValue("nam2", nam2);
      cmd.Parameters.AddWithValue("dat", dat);
      //Finally we open the connection
      con.Open();
      //Lastly we tell the sql command to execute on the database, in this case inserting
      //the values
      int i = cmd.ExecuteNonQuery();
      //Here we have the results of the execution stored in an integer, this is because
      //ExecuteNonQuery returns the number of rows it has effected, in the case of this
      //Insert statement it would effect one row by creating it, therefore i is 1
      //This is useful for determining if your sql statement was successfully executed
      //As if it returns 0, nothing has happened and something has gone wrong
      con.Close();
    }
