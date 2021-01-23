    public DataTable GetResultsOfAllDB(string query)
            {
                using (SqlConnection con = new SqlConnection(_ConnectionString))
                {
                    string locleQuery = "select name from [master].sys.sysdatabases";
                    DataTable dtResult = new DataTable("Result");
                    using (SqlCommand cmdData = new SqlCommand(locleQuery, con))
                    {
                        cmdData.CommandTimeout = 0;
    
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmdData))
                        {
    
                            using (DataTable dtDataBases = new DataTable("DataBase"))
                            {
                                adapter.Fill(dtDataBases);
    
                                foreach (DataRow drDB in dtDataBases.Rows)
                                {
                                    if (dtResult.Rows.Count >= 15000)
                                        break;
                                    locleQuery = " Use [" + Convert.ToString(drDB[0]) + "]; " + query;
                                    cmdData = new SqlCommand(locleQuery, con);
                                    adapter = new SqlDataAdapter(cmdData);
                                    using (DataTable dtTemp = new DataTable())
                                    {
                                        adapter.Fill(dtTemp);
                                        dtResult.Merge(dtTemp);
                                    }
                                }
                                return dtResult;
                            }
                        }
                    }
                }
            }
