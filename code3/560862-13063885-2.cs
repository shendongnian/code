        int a;
        String constring = ConfigurationManager.ConnectionStrings["conn"].ConnectionString.ToString();
        public int Autonumber()
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                SqlCommand cmd = new SqlCommand
                                     {
                                         CommandType = CommandType.Text,
                                         Connection = con,
                                         CommandText = "select pid from pid",
                                     };
                con.Open();
                // cmd.Connection.Open();
                using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                            a = reader.GetInt32(0);
                    }
                }
                return a;
            }
        }
