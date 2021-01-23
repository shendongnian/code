    private SqlDataReader TestMethod(string sqlCmd, List<string> myColumns)
    {
     try{
         SqlDataReader myReader = null;
         SqlCommand    myCommand = new SqlCommand(sqlCmd, myConnection);
         myReader = myCommand.ExecuteReader();
         return myReader;
       }
       catch (Exception e)
       {
         Console.WriteLine(e.ToString());
       }
    }
