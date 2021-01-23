    public static dynamic SelectIntoItem(string SQLselect, string connectionString, CommandType cType = CommandType.Text, object parms = null)
    {
      using (SqlConnection conn = new SqlConnection(connectionString))
      {
        using (SqlCommand cmd = conn.CreateCommand())
        {
          dynamic result = new System.Dynamic.ExpandoObject();
          cmd.CommandType = cType;
          cmd.CommandText = SQLselect;
          if (parms != null)
            Addparms(cmd, parms);
          conn.Open();
          using (SqlDataReader reader = cmd.ExecuteReader())
          {
            if (reader.Read())  // read the first one to get the columns collection
            {
              var cols = reader.GetSchemaTable()
                           .Rows
                           .OfType<DataRow>()
                           .Select(r => r["ColumnName"]);
              foreach (string col in cols)
              {
                ((IDictionary<System.String, System.Object>)result)[col] = reader[col];
              }
              result.Empty = false;
              if (reader.Read())
              {
                // error, what to do?
                result.Error = true;
                result.ErrorMessage = "More than one row in result set.";
              }
              else
              {
                result.Error = false;
              }
            }
            else
            {
              result.Empty = true;
              result.Error = false;
            }
          }
          conn.Close();
          return result;
        }
      }
    }
    private static void Addparms(SqlCommand cmd, object parms)
    {
      // parameter objects take the form new { propname : "value", ... } 
      foreach (PropertyInfo prop in parms.GetType().GetProperties())
      {
        cmd.Parameters.AddWithValue("@" + prop.Name, prop.GetValue(parms, null));
      }
    }
