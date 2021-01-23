                using (SqlConnection conn = Connection)
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"SELECT *
                                            FROM [Your Tables]
                                            WHERE TagID = @TagID";
                        cmd.Parameters.Add(new SqlParameter("@TagID", SqlDbType.UniqueIdentifier) { Value = variableName});
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataSet dataSet = new DataSet();
                            adapter.Fill(dataSet, "datatablename");
                            return dataSet.Tables["datatablename"];
                        }
                    }
                }
