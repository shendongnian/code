    using (SqlConnection connection = new SqlConnection()) {
        connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        try {
            connection.Open();
        }
        catch() {
    	    ...
        }
    }
