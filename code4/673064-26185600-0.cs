    Try
    {
      using (SqlCommand cmd = new SqlCommand(querrystring, connection))
      {
        cmd.ExecutenonQuerry();
      }
     }
     catch
     {
        return;
      }
