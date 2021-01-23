    public string GetUserFinal(string _userInput)
    {
        string temp = "";
        using (SqlConnection myConn = new SqlConnection(Conn))
        {
            using (SqlCommand myCommand = new SqlCommand())
            {
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "dbo.your procedure name";
                myCommand.Parameters.AddWithValue("@SearchItem", _userInput);
                SqlDataReader reader = myCommand.ExecuteReader();
                myCommand.Connection = myConn;
                While (reader.read())
                {
                    //populate a string? or do something else?
                }
            }
        }
        return temp;
    }
