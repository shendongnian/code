       public string[] GetCustomers(string prefix)
        {
            prefix += "%";
            List<string> customers = new List<string>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager
                        .ConnectionStrings["constr"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select distinct drug_name from rx where drug_name like @SearchText";
                    cmd.Parameters.AddWithValue("@SearchText", prefix);
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            customers.Add(string.Format("{0}}", rdr["drug_name"]));
                        }
                    }
                    conn.Close();
                }
                return customers.ToArray();
            }
        }
    }
