    using (SqlConnection con = new SqlConnection("Your Connection String"))
    {
        using (SqlCommand cmd = new SqlCommand("Your Stored Procedure Name", con))
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = "Parameter Name";
            param.Value = "Value";
            param.SqlDbType = SqlDbType.VarChar;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);
            using (IDataReader DR = cmd.ExecuteReader())
            {
                if (DR.Read())
                {
                }
            }
        }
    }
