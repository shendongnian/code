    HashSet<SomeObject> dataLines = new HashSet<SomeObject>(); 
 
    foreach (var entity in someCollection)
            {
				if(entity == somecondition)
				{
					  dataLines.Add(new SomeObject
                                  {
                                      CollectionItem1 = entity.Property1,
                                      CollectionItem2 = entity.Property2,
                                      CollectionItem3 = entity.Property3,
                                      CollectionItem4 = entity.Property4,
                                      CollectionItem5 = entity.Property5,
                                      CollectionItem6 = entity.Property6,
                                      CollectionItem7 = entity.Property7,
                                  });
				}
			}
            try
            {
                _context.Connection.Open();
                EntityConnection connection = _context.Connection as EntityConnection;
                SqlConnection sqlConnection = null;
                if (connection != null)
                {
                    sqlConnection = connection.StoreConnection as SqlConnection;
                }
                if (sqlConnection != null)
                {
                    
                    SqlBulkCopy bulkInsert = new SqlBulkCopy(sqlConnection);
                    bulkInsert.DestinationTableName = "SomeTable";
                    bulkInsert.ColumnMappings.Add("CollectionItem1", "Column1");
                    bulkInsert.ColumnMappings.Add("CollectionItem2", "Column2");
                    bulkInsert.ColumnMappings.Add("CollectionItem3", "Column3");
                    bulkInsert.ColumnMappings.Add("CollectionItem4", "Column4");
                    bulkInsert.ColumnMappings.Add("CollectionItem5", "Column5");
                    bulkInsert.ColumnMappings.Add("CollectionItem6", "Column6");
                    bulkInsert.ColumnMappings.Add("CollectionItem7", "Column7");
    // dataLines is a collection of objects
                    bulkInsert.WriteToServer(dataLines.AsDataReader());
                    _context.SaveChanges();
                }
            }
            finally
            {
                _context.Connection.Close();
            }
