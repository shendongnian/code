    using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = con.CreateCommand())
            {
                List<DetailsClass> details = new List<DetailsClass>();
                DetailsClass dtl;
                try
                {
                    con.Open();
                    cmd.CommandText = "Stored Procedure Name";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MyParameter", myparameter);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dtl = new DetailsClass((
                                reader.GetInt32(reader.GetOrdinal("MEMBERSHIPGEN"))),
                                reader.IsDBNull(1) ? null : reader.GetString(reader.GetOrdinal("EMAIL")),
                                reader.GetNullableDateTime("STARTINGDATE"));
                            details.Add(dtl);
                        }
                        reader.Close();
                        return details;
                    }
                }
