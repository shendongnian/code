    public static object ExecuteActionProcedure(System.Data.CommandType CommandType, string CommandText, string[] Parameters, object[] Values)
    {
      try
      {
        using (SqlConnection con = new SqlConnection())
        {
          con.ConnectionString = ConfigurationManager.ConnectionStrings["YourConnection"].ConnectionString;
          con.Open();
          using (SqlCommand cmd = new SqlCommand())
          {
            cmd.Connection = con;
            cmd.CommandType = CommandType;
            cmd.CommandText = CommandText;
            SqlParameter result = new SqlParameter();
            result.ParameterName = "ResultValue";
            result.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(result);
            for (int i = 0; i < Parameters.Length; i++)
            {
              cmd.Parameters.AddWithValue(Parameters[i], Values[i]);
            }
            cmd.ExecuteNonQuery();
            return (int)result.Value;
          }
        }
      }
        }
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
        return null;
      }
    }
