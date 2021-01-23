    public void SetupParams(string RoutineName, OracleCommand cmd, IDictionary<string, string> prms, bool keepConnectionOpen = true)
                {
                Debug.WriteLine("Setting parameters for " + RoutineName);
                if (cmd != null) cmd.Parameters.Clear();
                string pname = "";
                string[] s = RoutineName.Split('.');
                DataTable tblParams = Select(String.Format("Select * from Table(pkgUtils.ftRoutineSchema('{0}','{1}')) ", s[0], s[1]));
               cmd.CommandText=RoutineName; 
               foreach (DataRow dr in tblParams.Rows)
                    {
                    using (OracleParameter p = new OracleParameter())
                        {
                        pname = dr["COLUMnNAME"].ToString() == "" ? "returnvalue" : pname = dr["COLUMnNAME"].ToString().ToLower();
                        if (prms.Keys.Contains(pname)) p.Value = prms[pname];
                        string direction = dr["Direction"].ToString().ToLower();
                        string sptype = (string)dr["DataType"];
                        string[] sx = dr["DataType"].ToString().Split(new char[] { '(', ',', ')' });
                        direction = pname == "returnvalue" ? "rc" : direction;
                        p.ParameterName = pname;
                        #region case type switch
                        switch (sx[0].ToLower())
                            {
                            case "number":
                                // p.DbType = OracleDbType.Decimal;
                                p.OracleDbType = OracleDbType.Decimal;
                                break;
    
                            case "varchar2":
                                p.DbType = DbType.String;
                                p.Size = 65536;
                                //  p.Size = prms[pname].Length;
                                // p.Size = int.Parse(sx[1]);
                                break;
                            case "ref cursor":
                                p.OracleDbType = OracleDbType.RefCursor;
                                // direction = "rc"; // force return value
    
                                break;
                            case "datetime":
                                p.DbType = DbType.DateTime;
                                break;
                            case "ntext":
                            case "text":
                                p.DbType = DbType.String;
                                p.Size = 65536;
                                break;
                            default:
                                break;
                            }
                        //-------------------------------------------------------------------------------
                        switch (direction)
                            {
                            case "in": p.Direction = ParameterDirection.Input; break;
                            case "out": p.Direction = ParameterDirection.Output; break;
                            case "in/out": p.Direction = ParameterDirection.InputOutput; break;
                            case "rc": p.Direction = ParameterDirection.ReturnValue; break;
                            default: break;
                            }
    
                        #endregion
                        cmd.Parameters.Add(p); ;
                        }
                    }
                } 
