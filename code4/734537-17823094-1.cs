                var FilesWith48Fields = Directory.GetFiles(@"D:\Data\48Fields", "*.csv");
    
                foreach (var fileName in FilesWith48Fields)
                {
                    using (var file = new StreamReader(fileName))
                    using (var csv = new CsvReader(file, true)) // true = has header row
                    using (var bcp = new SqlBulkCopy(connection, SqlBulkCopyOptions.KeepNulls))
                    {
                        bcp.DestinationTableName = "fletchsodTable";
                        // map the first field of your CSV to the column in Database
                        var mapping1 = new SqlBulkCopyColumnMapping(0, "FirstColumnName");
                        bcp.ColumnMappings.Add(mapping1);
                         
                        var mapping2 = new SqlBulkCopyColumnMapping(1, "SecondColumnName");
                        bcp.ColumnMappings.Add(mapping2);  
                        ....
                        
                        bcp.WriteToServer(csv);
                    }
                }
