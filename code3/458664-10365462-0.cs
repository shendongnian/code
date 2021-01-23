            using (SqlConnection conn = new SqlConnection("connString"))
            {
                int counter = 0;
                using (SqlCommand cmd = new SqlCommand("SELECT people FROM tblPeople", conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.GetValue(0) != DBNull.Value)
                        {
                            counter = (int)reader[0];
                        }
                    }
                }
                using (SqlCommand cmd = new SqlCommand("UPDATE tblPeople SET people = @myCounter", conn))
                {
                    cmd.Parameters.Add("@myCounter", System.Data.SqlDbType.Int).Value = ++counter;
                    cmd.ExecuteNonQuery();
                }
            }
