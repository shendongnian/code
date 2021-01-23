    string someconnectionstring = "yourConnectionString";
    if (!string.IsNullOrEmpty(someconnectionstring))
    {
        using (SqlConnection sconn = new SqlConnection(someconnectionstring))
        {
            using (SqlCommand scmd = new SqlCommand("mydb.[dbo].[myStoredProc]", sconn))
            {
                scmd.CommandType = CommandType.StoredProcedure;
                scmd.Parameters.Add("@valueX", SqlDbType.VarChar).Value = 2;
                scmd.Parameters.Add("@returnValue", SqlDbType.Int);
                scmd.Parameters["@returnValue"].Direction = ParameterDirection.Output;
                sconn.Open();  //code throw exception here but continues to work.
                SqlDataReader adar = scmd.ExecuteReader();
                if (adar.HasRows)
                {
                    while (adar.Read())
                    {
                        //...
                    }
                }                
                sconn.Close();
            }
        }
    }
