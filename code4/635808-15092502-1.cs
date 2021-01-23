    if (IsValid(tbxDatabase.Text))
    {
        SqlConnection myConnection = new SqlConnection(ConnectionString);
        string myQuery = "CREATE DATABASE [" + tbxDatabase.Text + "]";
        myConnection.Open();
        SqlCommand myCommand = new SqlCommand(myQuery, myConnection);
        myCommand.ExecuteNonQuery();
    }
    else
    {
        // invalid name
    }
