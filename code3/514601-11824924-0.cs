     SqlConnection conn = new SqlConnection (yourconnectionstring);
     conn.ConnectionTimeout = 1;
     try
     { 
         conn.Open();
         conn.Close();
     }
     catch (Exception ex)
     {
         // invalid.
     }
