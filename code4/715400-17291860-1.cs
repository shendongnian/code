    private void TestMethod(string sqlCmd, List<string> myColumns)
    {
        try
        {
            SqlDataReader myReader = null;
            SqlCommand    myCommand = new SqlCommand(sqlCmd, myConnection);
            myReader = myCommand.ExecuteReader();
            while(myReader.Read())
            {
                foreach (var col in myColumns)
                {   
                   Console.WriteLine(myReader[col].ToString());                   
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }
