            SqlConnection con  = new SqlConnection(strcon);
            // Just created, never open....
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
 
