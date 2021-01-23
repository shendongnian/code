    private void DsataBaseInteraction()
    {
        using (SqlConnection con = new SqlConnection("Your Connection String"))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "Your Stored Procedure name";
                using (SqlDataReader DR = cmd.ExecuteReader())
                {
    
                }
            }
        }
    }
