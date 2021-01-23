    using (SqlConnection conn = new SqlConnection("[QueryString]")) {
                using (SqlCommand cmd = new SqlCommand("SQL Command",conn)) {
                    //here you return the number of affected rows
                    int a = cmd.ExecuteNonQuery();                    
                }
            }
