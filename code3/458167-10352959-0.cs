    SqlConnection connection = null;
    try {
        connection.Open();
        
        // Do stuff like run a query, setup your IDbCommand, etc.
    catch (Exception ex) {
        // Log error
    } finally {
        if (connection != null) {
            connection.Close();
        }
    }
