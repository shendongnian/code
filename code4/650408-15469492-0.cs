     // Connect to Excel files
     System.Data.OleDb.OleDbConnection MyConnection ;
     System.Data.DataSet ds ;
     System.Data.OleDb.OleDbDataAdapter MyCommand ;
     MyConnection = new System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;Data Source='D:\\18.xls';Extended Properties=Excel 8.0;");
     MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection);
     MyCommand.TableMappings.Add("Table", "Product");
     ds = new System.Data.DataSet();
     MyCommand.Fill(ds);
     MyConnection.Close();
     // Write to xml
     ds.WriteXml("Product.xml");
