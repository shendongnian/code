    SqlConnection conn = new SqlConnection(connectionString);
    
    using (conn)
    {
    SqlCommand com = new SqlCommand("Select * from mytable",conn);
    
    DataReader reader = com.ExecuteReader();
    
    TextWriter writer = new TextWriter("myFile.txt");
    while (reader.read())
    {
    StringBuilder myData = new StringBuilder();
    myData.Append(reader["Fname"].toString();
    //etc - see how you want to format it
    
    writer.WriteLine(myData.ToString());
    }
    
    
    }
