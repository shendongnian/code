     using (SqlConnection OIMS_01 = new SqlConnection(connString))
     {
          SqlCommand OIMScmd = new SqlCommand(OIMSquery, OIMS_01);
          try
          {
              OIMS_01.Open();
              int i = (int)OIMScmd.ExecuteScalar();
          }
          catch (Exception ex)
          {
              Console.WriteLine(ex.Message);
          }
     }
