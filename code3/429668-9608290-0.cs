    public static string GetBalance() {
    
       string result = string.Emtpy;
       using (var connection = /* Build your SqlConnection */) {
          using (var cmd = new SqlCommand("your select command here", connection) {
             try 
             {
                connection.Open();
                // you don't need a reader to take just a single value
                object value = cmd.ExecuteScalar();
                if (value != null) 
                   result = value.ToString();
             }
             catch(Exception ex)
             {
                /* you've got an error */
             }         
             finally 
             {
                connection.Close();
             }         
          }
       }
       return result;
    }
