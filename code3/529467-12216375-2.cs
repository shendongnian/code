    using (OracleConnection oraConn = new OracleConnection(connStr))
                    {
                        string cmdText = @"insert into TEST_EVENT
                            (EVENT_NAME, EVENT_DESC)
                            values
                            (:EVENT_NAME, :EVENT_DESC)
                            RETURNING EVENT_ID INTO :EVENT_ID
                            ";
     
                        using (OracleCommand cmd = new OracleCommand(cmdText, oraConn))
                        {
                            oraConn.Open();
                            OracleTransaction trans = oraConn.BeginTransaction();
                            try
                            {
                                string[] event_names = new string[2];
                                string[] event_descs = new string[2];
                                int[] event_ids = new int[2];
     
                                event_names[0] = "Event1";
                                event_descs[0] = "Desc1";
     
                                event_names[1] = "Event2";
                                event_descs[1] = "Desc2";
     
                                OracleParameter prm = new OracleParameter();
                                cmd.Parameters.Clear();
                                cmd.ArrayBindCount = 2;
                                cmd.BindByName = true;
     
                                prm = new OracleParameter("EVENT_NAME", OracleDbType.Varchar2); prm.Value = event_names; cmd.Parameters.Add(prm);
                                prm = new OracleParameter("EVENT_DESC", OracleDbType.Varchar2); prm.Value = event_descs; cmd.Parameters.Add(prm);
                                prm = new OracleParameter("EVENT_ID", OracleDbType.Int32, ParameterDirection.ReturnValue); cmd.Parameters.Add(prm);
     
                               
                                cmd.ExecuteNonQuery();
                                trans.Commit();
                                // get return values
     
                                event_ids = (int[])(cmd.Parameters["EVENT_ID"].Value);
                            }
                            catch
                            {
                                trans.Rollback();
                                throw;
                            }
                            finally
                            {
                                trans.Dispose();
                            }
                            oraConn.Close();
                        }
                    }
