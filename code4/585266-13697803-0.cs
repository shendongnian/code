      using (var cmd = new SqlCommand("myQSProcedure_Delete", conn))
      {
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.Parameters.Add("@Id",SqlDbType.Int);
          foreach (DataRow row in dtDelete.Rows)
          {
              cmd.Parameters["@Id"].Value = row[0];
              cmd.ExecuteNonQuery();
          }
      }
