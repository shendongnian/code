    DataTable dt = new DataTable();
     //dt = dataGridView1.DataSource as DataTable; //<-remove this
     DataSet ds = new DataSet();
     ds.Tables.Add(dt);
     ds.WriteXml(@"e:\results.xml", System.Data.XmlWriteMode.IgnoreSchema);
