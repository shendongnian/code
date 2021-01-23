       try
            {
               string excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                                   "Data Source=" + Path of File + ";" +
                                  @"Extended Properties=""Excel 12.0 Xml;HDR=Yes""";
                //Create Connection to Excel work book
                OleDbConnection excelConnection =
                new OleDbConnection(excelConnectionString);
                //Create OleDbCommand to fetch data from Excel
                OleDbCommand cmd = new OleDbCommand
                ("Select * from [Sheet1$]",
                excelConnection);
              
                excelConnection.Open();
               
                OleDbDataReader dReader;
                dReader = cmd.ExecuteReader();
                SqlBulkCopy sqlBulk = new SqlBulkCopy(strConnection);
                sqlBulk.DestinationTableName = "ExcelTable";  // write your table name
               
                //sqlBulk.ColumnMappings.Add("ID", "ID");
                //sqlBulk.ColumnMappings.Add("Name", "Name");
                sqlBulk.WriteToServer(dReader);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
