         string sqlInsert="";
        
            foreach (DataGridViewRow r in DataGridView1.Rows)
             {
             if (r.Cells[0].Value != null)
                                    {
                                        Ticker = r.Cells[1].Value.ToString().Trim();
            
                                        string values = "'" + tt.Trim() + "',";
                                        values += "'" + r.Cells[1].Value.ToString().Trim() + "',"; // Ticker
                                        values += (r.Cells[2].Value.ToString().Trim() == "" ? 0 : Convert.ToDouble(r.Cells[2].Value.ToString().Trim())) + ",";    // LTP                        
                                        values += Convert.ToDouble("0") + ","; // Open
                                        values += (r.Cells[3].Value.ToString().Trim() == "" ? 0 : Convert.ToDouble(r.Cells[3].Value.ToString().Trim())) + ","; // High
                                        values += (r.Cells[4].Value.ToString().Trim() == "" ? 0 : Convert.ToDouble(r.Cells[4].Value.ToString().Trim())) + ","; // LOW
                                        values += (r.Cells[5].Value.ToString().Trim() == "" ? 0 : Convert.ToDouble(r.Cells[5].Value.ToString().Trim())) + ","; // Close
                                        values += (r.Cells[6].Value.ToString().Trim() == "" ? 0 : Convert.ToDouble(r.Cells[6].Value.ToString().Trim())) + ","; // YCP
                                        if (r.Cells[7].Value.ToString().Trim() == "--" || r.Cells[7].Value.ToString().Trim() == "")
                                            chg_Prc = "0";
                                        else
                                            chg_Prc = r.Cells[7].Value.ToString().Trim();
                                        values += Convert.ToDouble(chg_Prc.Trim()) + ","; // Change
                                        values += (r.Cells[8].Value.ToString().Trim() == "" ? 0 : Convert.ToDouble(r.Cells[8].Value.ToString().Trim())) + ","; // Trade No
                                        values += (r.Cells[9].Value.ToString().Trim() == "" ? 0 : Convert.ToDouble(r.Cells[9].Value.ToString().Trim())) + ","; // Volume
                                        values += Convert.ToDouble("0") + ",";
                                        if (r.Cells[2].Value.ToString().Trim() == "0.0" || r.Cells[2].Value.ToString().Trim() == "0.00" || r.Cells[2].Value.ToString().Trim() == "0")
                                            tradeStatus = "N";
                                        else
                                            tradeStatus = "Y";
                                        values += "'" + tradeStatus.Trim() + "',0";
            
                                        sqlInsert=sqlInsert+"Insert into " + tblName + " VALUES(" + values + ")";
                                    }
                                }
    ExecuteSQL(sqlInsert);
