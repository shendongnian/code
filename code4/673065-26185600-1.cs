    Try
    {
      using (SqlCommand cmd = new SqlCommand(querystring, connection))
      {
        cmd.ExecutenonQuery();
      }
     }
     catch
     {
        return;
      }
