    private static void BulkInsertToSQL(DataTable dt, string tableName)
            {
                DateTime fileDate = Convert.ToDateTime(dt.Rows[0]["TradeDate"]);
                if (!InOptionsStats(fileDate))
                {
                    using (SqlConnection con = new SqlConnection(_DB))
                    {
                        SqlBulkCopy sbc = new SqlBulkCopy(con);
                        sbc.DestinationTableName = tableName;
    
                        //if your DB col names don’t match your XML element names 100%
                        //then relate the source XML elements (1st param) with the destination DB cols
                        sbc.ColumnMappings.Add("DBAttributeName1", "DTColumnName1");
                        sbc.ColumnMappings.Add("DBAttributeName2", "DTColumnName2");
                        sbc.ColumnMappings.Add("DBAttributeName3", "DTColumnName3");
                        sbc.ColumnMappings.Add("DBAttributeName4", "DTColumnName4");
    
                        con.Open();
    
                        sbc.WriteToServer(dt);
                        con.Close();
                    }
                }
                
            }
