    string connetionString = null;
    string sql = null;
    // All the info required to reach your db. See connectionstrings.com
    connetionString = "Data Source=UMAIR;Initial Catalog=Air; Trusted_Connection=True;" ;
    // Prepare a proper parameterized query 
    sql = "insert into Main ([Firt Name], [Last Name]) values(@first,@last)";
    // Create the connection (and be sure to dispose it at the end)
    using(SqlConnection cnn = new SqlConnection(connetionString))
    {
       // Open the connection to the database. 
       // This is the first critical step in the process.
       // If we cannot reach the db then we have connectivity problems
       cnn.Open();
       // Prepare the command to be executed on the db
       using(SqlCommand cmd = new SqlCommand(sql, cnn))
       {
           // Create and set the parameters values 
           cmd.Parameters.Add("@first", SqlDbType.NVarChar).Value = textbox2.text;
           cmd.Parameters.Add("@last", SqlDbType.NVarChar).Value = textbox3.text;
           // Let's command the db to execute the query
           cmd.ExecuteNonQuery();
           MessageBox.Show ("Row inserted !! ");
       }
    }
