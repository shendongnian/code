    StreamWriter YourWriter = new StreamWriter(@"c:\testfile.txt");
    SqlCommand YourCommand = new SqlCommand();
    SqlConnection YourConnection = new SqlConnection(YourConnectionString);
    YourCommand.Connection = YourConnection;
    YourCommand.CommandText = myQuery;
    
    YourConnection.Open();
    
    using (YourConnection)
    {
        using (SqlDataReader sdr = YourCommand.ExecuteReader())
            using (YourWriter)
            {
                while (sdr.Read())
                    YourWriter.WriteLine(sdr[0].ToString() + sdr[1].ToString() + ",");
    
            }
    }
