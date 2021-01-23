    private int SelectByStoredProcedureGetAvailablePlaces(string entryParam1, string   entryParam2, DateTime entryParam3)
    {
            int results;
            //PlanningElement plan = GetPlanningElement(entryParam1, entryParam2, entryParam3.ToString(), "31/12/2012 00:00:00", "150");
    
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
    
                sqlCommand.CommandText = "GET_AVAILABLE_PLACES";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("eventGuid", entryParam1);
                sqlCommand.Parameters.AddWithValue("placeGuid", entryParam2);                
                sqlCommand.Parameters.AddWithValue("dateGuid", entryParam3);
    
                SqlParameter returnValueParam = sqlCommand.Parameters.Add("@ReturnValue", SqlDbType.Int);
                returnValueParam.Direction = ParameterDirection.Output;
                
                sqlConnection.Open();
    
                sqlCommand.ExecuteNonQuery();
                result = returnValueParam.Value;
    
                sqlConnection.Close();
            }
    
            return results;
