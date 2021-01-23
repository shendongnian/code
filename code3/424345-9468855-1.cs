    SqlConnection mySqlConnection =new SqlConnection("server=(local)\\SQLEXPRESS;database=MyDatabase;Integrated Security=SSPI;");
    SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
    mySqlCommand.CommandText ="select columnname from Children where Child_ID = @Child_ID";
     mySqlCommand .Parameters.Add("@Child_ID", SqlDbType.Int);
     mySqlCommand .Parameters["@Child_ID"].Value = idvalue;
     mySqlConnection.Open();
     SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader(CommandBehavior.SingleRow);
    while (mySqlDataReader.Read()){
      Console.WriteLine("mySqlDataReader[\" columnname\"] = " +
        mySqlDataReader["columnname"]);
    }
    mySqlDataReader.Close();
    mySqlConnection.Close();
