    public DataSet execProc2DatSet(string storedProcedureName, IDictionary<string, string> prms, bool propagateDbInfo, bool leaveConnectionOpen = false)
                {
               // initPackage(storedProcedureName.Substring(0,storedProcedureName.IndexOf('.')));
                try
                    {
                    using (OracleCommand cmd = new OracleCommand("", conn))
                        {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = storedProcedureName;
                        //dep = new OracleDependency(cmd);
                        //dep.OnChange += new OnChangeEventHandler(dep_OnChange);
                        if (prms != null) SetupParams(storedProcedureName, cmd, prms, true);
                        using (OracleDataAdapter da = new OracleDataAdapter(cmd))
                            {
                            if (conn.State != ConnectionState.Open)
                                {
                                conn.Open();
                                cmd.Connection = conn;
                                }
                            using (DataSet ds = new DataSet())
                                {
                                da.Fill(ds);
                                return ds;
                                }
                            }
                        }
                    }
                catch (Exception ex)
                    {
                    Debug.WriteLine(ex);
                    Debugger.Break();
                    return null;
                    }
                finally
                    {
                    if (!leaveConnectionOpen) conn.Close();
                    }
                }
