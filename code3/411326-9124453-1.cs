        private void BulkCopy(OleDbDataReader reader, string tableName, Table table)
        {
            Console.WriteLine(tableName + " BulkCopy Started.");
            try
            {
                DataTable tbl = new DataTable();
                List<Type> typeList = new List<Type>();
                foreach (Column col in table.Columns)
                {
                    tbl.Columns.Add(col.Name, ConvertDataTypeToType(col.DataType));
                    typeList.Add(ConvertDataTypeToType(col.DataType));
                }
                int batch = 1;
                int counter = 0;
                DataRow tblRow = tbl.NewRow();
                while (reader.Read())
                {
                    counter++;
                    int colcounter = 0;
                    foreach (Column col in table.Columns)
                    {
                        try
                        {
                            tblRow[colcounter] = reader[colcounter];
                        }
                        catch (Exception)
                        {
                            tblRow[colcounter] = GetDefault(typeList[0]);
                        }
                        colcounter++;
                    }
                    tbl.LoadDataRow(tblRow.ItemArray, true);
                    if (counter == BulkInsertIncrement)
                    {
                        Console.WriteLine(tableName + " :: Batch >> " + batch);
                        counter = PerformInsert(tableName, tbl, batch);
                        batch++;
                    }
                }
                if (counter > 0)
                {
                    Console.WriteLine(tableName + " :: Batch >> " + batch);
                    PerformInsert(tableName, tbl, counter);
                }
                tbl = null;
                Console.WriteLine("BulkCopy Success!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("BulkCopy Fail!");
                SharedLogger.Write(ex, @"C:\BulkCopy_Errors.txt", tableName);
                Console.WriteLine(ex.Message);
            }
            finally
            {
                reader.Close();
                reader.Dispose();
            }
            Console.WriteLine(tableName + " BulkCopy Ended.");
            Console.WriteLine("*****");
            Console.WriteLine("");
        }
