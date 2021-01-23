             private void BulkCopy(OleDbDataReader reader, string tableName)    
             {
                 Console.WriteLine(tableName + " BulkCopy Started.");
                 try
                 {
                     DataTable tbl = new DataTable();
                     tbl.Load(reader);
                     reader.Close();
                     reader.Dispose();
                     DataTable holderTable = tbl.Clone();
     
                     int BuckInsertIncrement = Convert.ToInt32(ConfigurationManager.AppSettings["BuckInsertIncrement"]);
                     
                     int batch = 1;
                     int counter = 0;
                     foreach (DataRow row in tbl.Rows)
                     {
                         counter++;
                         holderTable.ImportRow(row);
     
                         if (counter == BuckInsertIncrement)
                         {
                             Console.WriteLine(tableName + " :: Batch >> " + batch);
                             counter = PerformInsert(tableName, holderTable, batch);
                             batch++;
                         }
                     }
     
                     if (counter > 0)
                     {
                         Console.WriteLine(tableName + " :: Batch >> " + batch);
                         PerformInsert(tableName, holderTable, counter);
                     }
     
                     tbl.Dispose();
                     holderTable.Dispose();
     
                     Console.WriteLine("BulkCopy Success!");
                 }
                 catch (Exception ex)
                 {
                     Console.WriteLine("BulkCopy Fail!");
                     LogText(ex, @"C:\BulkCopy_Errors.txt", tableName);
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
