    public static int GetConveyorProductionCount(string machineNameV, DateTime StartTimeV, DateTime EndTimeV)
    {
      {
      using (SqlConnection connection = new SqlConnection(myConnectionString))
      {
        connection.Open();
        using(SqlCommand command = new SqlCommand(String.Format(CultureInfo.InvariantCulture, "SELECT cast([{0}] as int) FROM VWCONVEYORPRODUCTION WHERE([DA_TE] BETWEEN @StartDate AND @EndDate)", machineNameV), connection);            
        {
          command.Parameters.AddWithValue("StartDate",StartTimeV);
          command.Parameters.AddWithValue("StartDate",EndTimeV);
          object result = command.ExecuteScalar();
          if (result == DBNull.Value)
          {
            return 0;
          }
          else
          {
            return (Int32)result;
          }
        }
      }
    }
