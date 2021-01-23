     SqlConnection conn = new SqlConnection (yourconnectionstring + ";Connection Timeout=1;");          
     try
     { 
         conn.Open();
         conn.Close();
     }
     catch (Exception ex)
     {
         // invalid.
     }
