    try{
         SqlDataReader myReader = null;
         SqlCommand    myCommand = new SqlCommand("select * from table", myConnection);
         myReader = myCommand.ExecuteReader();
         return myReader;
    }
    catch (Exception e)
    {
         Console.WriteLine(e.ToString());
    }
