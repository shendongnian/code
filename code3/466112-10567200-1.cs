    static void Main(string[] args)
            {
                // Create Reader
                var reader = GetReader();
     
                // DB connection string
                var connectionString = @"Server={blah};initial catalog={blah-blah};Integrated Security=true";     
                
                using (var loader = new SqlBulkCopy(connectionString, SqlBulkCopyOptions.Default))
                {
                    loader.ColumnMappings.Add(0, 2);
                    loader.ColumnMappings.Add(1, 1);
                    loader.ColumnMappings.Add(2, 3);
                    loader.ColumnMappings.Add(3, 4);
     
                    loader.DestinationTableName = "Customers";
                    loader.WriteToServer(reader); 
     
                    Console.WriteLine("Done!");
                }
     
                Console.ReadLine();
            }
     
            static IDataReader GetReader()
            {
                var sourceFilepath = "sqlbulktest.txt";
                //our converters!
                var convertTable = GetConvertTable();
                var constraintsTable = GetConstraintsTable();
     
                var reader = new Reader(sourceFilepath, constraintsTable, convertTable);
                return reader;
            }
     
            static Func<string, bool>[] GetConstraintsTable()
            {
                var constraintsTable = new Func<string, bool>[4];
     
                constraintsTable[0] = x => !string.IsNullOrEmpty(x);
                constraintsTable[1] = constraintsTable[0];
                constraintsTable[2] = x => true;
                constraintsTable[3] = x => true;
                return constraintsTable;
            }
     
            static Func<string, object>[] GetConvertTable()
            {
                var convertTable = new Func<object, object>[4];
     
                convertTable[0] = x => x;
     
                
                convertTable[1] = x => x;
     
               
                // Convert to DateTime from specific format!
                convertTable[2] = x =>
                                  {
                                      DateTime datetime;
                                      if (DateTime.TryParseExact(x.ToString(), "dd.MM.yyyy", CultureInfo.InvariantCulture,
                                            DateTimeStyles.None, out datetime))
                                      {
                                          return datetime;
                                      }
                                      return null;
                                  };     
               
                convertTable[3] = x => Convert.ToInt32(x);
     
                return convertTable;
            }
