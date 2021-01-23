     DataTable tblDetails = new DataTable("tblPlanDetail");
            tblDetails.Columns.Add("row1").DataType = typeof(Int32);
            tblDetails.Columns.Add("row2").DataType = typeof(DateTime);
            tblDetails.Columns.Add("row3").DataType = typeof(String); ;
            tblDetails.Columns.Add("row4").DataType = typeof(Int32); ;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                
                for (int j = 1; j <= DateTime.DaysInMonth(monthYear.Year, monthYear.Month); j++)
                {
                    DataRow row = tblDetails.NewRow();
                    DateTime DayOfMonth = new DateTime(monthYear.Year, monthYear.Month, j);
                    row["row1"] = idPlan;
                    row["row2"] = DayOfMonth;
                    row["row3"] = table.Rows[i][0];
                    row["row4"] = Int32.Parse((string)table.Rows[i][j]);
                    tblDetails.Rows.Add(row);
                }
            }
            try
            {
                SqlBulkCopy sqlbulk = new SqlBulkCopy(connection, SqlBulkCopyOptions.KeepIdentity, transaction);
                sqlbulk.ColumnMappings.Add("row1", "row1");
                sqlbulk.ColumnMappings.Add("row2", "row2");
                sqlbulk.ColumnMappings.Add("row3", "row3");
                sqlbulk.ColumnMappings.Add("row4", "row4");
                sqlbulk.DestinationTableName = "tblPlanDescription";
                sqlbulk.BatchSize = 2;
                sqlbulk.WriteToServer(tblDetails);
                transaction.Commit();
            }
            catch (Exception exp)
            {
                transaction.Rollback();
            }
            finally
            {
                transaction.Dispose();
                connection.Close();
            }
