     SqlConnection conn = new SqlConnection (yourconnectionstring + ";Connection Timeout=1;");          
     try
     { 
         conn.Open();
         conn.Close();
     }
     catch (SqlException ex)
     {
         if (ex.Number == 18456)
         {
              // invalid login
         }
     }
