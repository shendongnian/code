     public static int RowCount()
            {
    
                string sqlConnectionString = @" Your connection string";
                SqlConnection con = new SqlConnection(sqlConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Expr1 FROM Tablename", con);
                int result = ((int)cmd.ExecuteScalar());
                con.Close();
                return result;
        }
