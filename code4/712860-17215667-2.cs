            // set connection
            SqlConnection sqlConnection = new SqlConnection("[Your connection string here]");
            
            // open connection
            sqlConnection.Open();
            // specify the stored procedure which has an output parameter, namely "NewId"
            SqlCommand insertcommandDet = new SqlCommand("[dbo].[TestingSP]", sqlConnection);
            // tell the command that it is a stored procedure
            insertcommandDet.CommandType = CommandType.StoredProcedure;
            // add the parameter having the name
            insertcommandDet.Parameters.AddWithValue("Name","Test Name"); 
            // this parameter will contain the new id after
            SqlParameter pID = new SqlParameter("NewId", SqlDbType.Int, 4);
            pID.Direction = ParameterDirection.Output;
            // add the parameter to the command
            insertcommandDet.Parameters.Add(pID);
            // execute command with ExecuteScalar()
            insertcommandDet.ExecuteScalar();
            // Get parameter value extracted with ExecuteScalar
            int id = Convert.ToInt32(insertcommandDet.Parameters["NewId"].Value.ToString());
