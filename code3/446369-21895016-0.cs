        public void writeToDBTable(DataTable dt)     
        {
            MySqlConnection conn = new MySqlConnection(globalClass.connString);
            conn.Open();
            String sql = null;
            String sqlStart = "insert into MyTable (run_id, model_id, start_frame,water_year, state_id, obligateCover, DTWoodyCover, perennialGrowth, clonalCover) values ";
            Console.WriteLine("Write to DB - Start. Records to insert  = {0}", dt.Rows.Count);
            int x = 0;            
            foreach (DataRow row in dt.Rows)
            {
                x += 1;
                    if (x == 1)
                    {
                        sql = String.Format(@"({0},{1},{2},{3},{4},{5},{6},{7},{8})",
                                              row["runId"],
                                              row["modelId"],
                                              row["startFrame"],
                                              row["waterYear"],
                                              row["currentFrame"],
                                              row["obligateCover"],
                                              row["DTWoodyCover"],
                                              row["perennialGrowth"],
                                              row["clonalCover"]
                                              );
                    }
                    else
                    {
                        sql = String.Format(sql + @",({0},{1},{2},{3},{4},{5},{6},{7},{8})",
                                              row["runId"],
                                              row["modelId"],
                                              row["startFrame"],
                                              row["waterYear"],
                                              row["currentFrame"],
                                              row["obligateCover"],
                                              row["DTWoodyCover"],
                                              row["perennialGrowth"],
                                              row["clonalCover"]
                                              );
                    }
                    if (x == 1000)
                    {
                       try
                       {
                           sql = sqlStart + sql;
                           MySqlCommand cmd = new MySqlCommand(sql, conn);
                           cmd.ExecuteNonQuery();
                           Console.WriteLine("Write {0}", x);
                           x = 0;
                       }
                       catch (Exception ex)
                        {
                            Console.WriteLine(sql);
                            Console.WriteLine(ex.ToString());
                        }
                    }
            }
            // get any straglers
            if (x > 0)
            {
                try
                {
                    sql = sqlStart + sql;
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Write {0}", x);
                    x = 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(sql);
                    Console.WriteLine(ex.ToString());
                }
            }
            conn.Close();
            Console.WriteLine("Write to DB - End.");
        }
