    Try
    {
      using (SqlCommand cmd = new SqlCommand(examplestring, connection))
      {
        cmd.ExecutenonQuery();
      }
     }
     catch
     {
        return;
      }
