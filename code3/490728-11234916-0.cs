     public DataTable ReadSchema(string strTable, string strConnectionString, string strAccessFileName)
        {
           DataTable schemaTable = new DataTable();
           schemaTable.Columns.Add("ColumnName", typeof(string));
           schemaTable.Columns.Add("ColumnSize", typeof(Int32));
           schemaTable.Columns.Add("NumericPrecision", typeof(Int32));
           schemaTable.Columns.Add("NumericScale", typeof(Int32));
           schemaTable.Columns.Add("DataType", typeof(string));
           schemaTable.Columns.Add("Length", typeof(string));
           try
           {
               using (var con = new OleDbConnection(strConnectionString))
               {
                   con.Open();
                   using (var cmd = new OleDbCommand("SELECT * FROM [" + strTable + "]", con))
                   using (var reader = cmd.ExecuteReader(CommandBehavior.SchemaOnly))
                   {
                       var table = reader.GetSchemaTable();
                      
                       foreach (DataRow row in table.Rows)
                       {
                           Console.WriteLine(row["ColumnName"].ToString() + " " + row["ColumnSize"].ToString() + " " + row["DataType"].ToString() + " " + row["NumericPrecision"].ToString() + " " + row["NumericScale"].ToString());
                           DataRow drRecord = schemaTable.NewRow();
                           drRecord["ColumnName"] = row["ColumnName"];
                           drRecord["ColumnSize"] = row["ColumnSize"];
                           drRecord["NumericPrecision"] = row["NumericPrecision"];
                           drRecord["NumericScale"] = row["NumericScale"];
                           drRecord["DataType"] = row["DataType"];
                          
                           schemaTable.Rows.Add(drRecord); 
                       }
                   }
               }
           }
           catch (Exception Ex)
           {
               
               string strMessage = "Selecting schema for table " + strTable + ". " + Environment.NewLine + Ex.Message;
               MessageBox.Show(strMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               tran.strErrors = tran.strErrors + strMessage + "\r\n";
               txtErrors.Text = txtErrors.Text + strMessage + "\r\n";
           }
            return (schemaTable);
        }
 
