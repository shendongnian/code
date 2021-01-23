            DataTable dtSource = null;
            //populate or assign dtSouurce here
            string connectionString = null;
            //assign your connection string here
            var tableName = "TABLE2";
            using (var connection = new SqlConnection(connectionString))
            {
                var adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(tableName, connection);
                adapter.SelectCommand.CommandType = CommandType.TableDirect;
                var builder = new SqlCommandBuilder(adapter);
                connection.Open();
                var dataSet = new DataSet();
                adapter.FillSchema(dataSet, SchemaType.Mapped);
                builder.GetInsertCommand();
                foreach (DataRow row in dtSource.Rows)
                {
                    dataSet.Tables[tableName].Rows.Add(row.ItemArray);
                    //dataSet.Tables[tableName].Rows.Add(new object[]{ row.ItemArray[0], row.ItemArray[2], "Some Else Values" });
                }
                adapter.Update(dataSet, tableName);
                connection.Close();
            }
