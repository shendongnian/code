            string[] parameters = new string[items.Count];
            SqlCommand SecondQuery = new SqlCommand();
            for (int i = 0; i < items.Count; i++)
            {
                parameters[i] = "'" + string.Format(items[i].Id) + "'";
                //SecondQuery.Parameters.AddWithValue(parameters[i], items[i]);
            }
            SecondQuery.CommandText = string.Format("SELECT * from S_analysis WHERE heat_no IN ({0})", string.Join(",", parameters));
            using (SqlConnection conn = new SqlConnection(strSQLconnection))
            {
                SecondQuery.CommandTimeout = 50000;
                conn.Open();
                SecondQuery.Connection = conn;
                using (var reader7 = SecondQuery.ExecuteReader())
                {
                    int fieldCount = reader7.FieldCount;
                    while (reader7.Read())
                    {
                        for (int i = 0; i < fieldCount; i++)
                        {
                            finalresults.Add(reader7[i].ToString());
                        }
                    }
                }
            }
