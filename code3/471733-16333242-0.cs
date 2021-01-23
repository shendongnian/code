    private static List<DataTable> SplitTable(DataTable originalTable, int batchSize)
    		{
    			List<DataTable> tables = new List<DataTable>();
    			
    			foreach (var rowBatch in originalTable.Rows.Cast<DataRow>().Batch(batchSize))
    			{
    				var batchTable = new DataTable(originalTable.TableName);
    
    				foreach (DataColumn column in originalTable.Columns)
    					batchTable.Columns.Add(column.ColumnName, column.DataType);
    				
    				foreach (DataRow row in rowBatch)
    					batchTable.Rows.Add(row.ItemArray);
    				
    				tables.Add(batchTable);
    			}
    			return tables;
    		}
