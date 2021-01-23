                using (OracleCommand cmnd = new OracleCommand(cmndText, con))
                {
                    if (parameters != null)
                    {
                        foreach (OracleParameter p in parameters)
                        {
                            cmnd.Parameters.Add(p);
                        }
                    }
                    try
                    {
                        cmnd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                    }
                }
