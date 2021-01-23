            using (var connection = new SqlConnection(connectionString)) 
            { 
                connection.Open(); 
 
                // Create all necessary ADO.NET objects. 
                var adapter = new SqlDataAdapter("SELECT * FROM MyTable", connection); 
                var dataSet = new DataSet(); 
                adapter.FillSchema(dataSet, SchemaType.Source, "MyTable"); 
                adapter.InsertCommand = new SqlCommandBuilder(adapter).GetInsertCommand(); 
                DataTable table = dataSet.Tables["MyTable"]; 
		DataColumn[0] key1 = dataSet.Tables["MyTable"].Columns["ItemID"];
                    key1[0].AutoIncrement = true;
                    key1[0].AutoIncrementSeed = 1;
                    key1[0].AutoIncrementStep = 1;
                    dataSet.Tables["MyTable"].PrimaryKey = key1;
                    key1 = null;
 
                int[] handles = EasyDAClient.DefaultInstance.SubscribeMultipleItems( 
                    new[] 
                        { 
                            new DAItemGroupArguments("", "MyOPCServer.1", "OPCItem01", 1000, null), 
                            new DAItemGroupArguments("", "MyOPCServer.1", "OPCItem02", 1000, null), 
                            new DAItemGroupArguments("", "MyOPCServer.1", "OPCItem03", 1000, null), 
                            new DAItemGroupArguments("", "MyOPCServer.1", "OPCItem04", 1000, null) 
                        },  
                    (_, eventArgs) => 
                        { 
                            if (eventArgs.Vtq != null) 
                            { 
                                // Fill a DataRow with the OPC data, and add it to a DataTable. 
                                table.Rows.Clear(); 
                                DataRow row = table.NewRow(); 
                                row["ItemID"] = eventArgs.ItemDescriptor.ItemId; 
                                row["Value"] = eventArgs.Vtq.Value; // The DataRow will make the conversion to a string. 
                                row["Timestamp"] = (eventArgs.Vtq.Timestamp < (DateTime) SqlDateTime.MinValue) 
                                                       ? (DateTime)SqlDateTime.MinValue 
                                                       : eventArgs.Vtq.Timestamp; 
                                row["Quality"] = (short)eventArgs.Vtq.Quality; 
                                table.Rows.Add(row); 
 
                                // Update the underlying DataSet using an insert command. 
                                adapter.Update(dataSet, "MyTable"); 
                            } 
                        } 
                    ); 
