    try
    {
        SqlDataReader myReader = null;
        SqlCommand    myCommand = new SqlCommand("select * from table", 
                                                 myConnection);
        myReader = myCommand.ExecuteReader();
        while(myReader.Read())
        {
            Console.WriteLine(myReader["Column1"].ToString());
            Console.WriteLine(myReader["Column2"].ToString());
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e.ToString());
    }
