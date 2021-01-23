    public DataTable Get_DTable(String Query, Dictionary<String, String> Parameters)
        {
            try
            {
                using (con = new SqlConnection(cls_Connection.URL()))
                {
                    if (con.State == 0)
                        con.Open();
                    using (cmd = new SqlCommand(Query, con))
                    {
                        foreach (KeyValuePair<string, string> item in Parameters)
                        {
                            cmd.Parameters.AddWithValue(item.Key, item.Value);
                        }
                        using (da = new SqlDataAdapter(cmd))
                        {
                            using (dt = new DataTable())
                            {
                                da.Fill(dt);
                                if (dt.Rows.Count > 0)
                                {
                                    return dt;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message,
                                "Information",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            return null;
        }
