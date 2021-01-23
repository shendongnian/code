    SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
    while(myReader.Read()) 
    {
    Console.WriteLine(myReader.GetString(0));
    }
    myReader.Close();
