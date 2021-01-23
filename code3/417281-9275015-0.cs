        var dataSet = new DataSet("TestDataSet");
        var dataTable = new DataTable("TestTable");
        dataTable.Columns.Add("ID", typeof(Int32));
        dataTable.Columns.Add("Value", typeof(string));
        dataTable.Rows.Add(1, "Value1");
        dataSet.Tables.Add(dataTable);
        dataSet.WriteXml(@"L:\ds.xml", XmlWriteMode.WriteSchema);
