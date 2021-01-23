        ADOX.Catalog cat = new ADOX.Catalog();
        ADOX.Table table = new ADOX.Table();
     
        table.Name = "Table1";
        table.Columns.Append("PartNumber", ADOX.DataTypeEnum.adVarWChar, 6); 
        table.Columns.Append("AnInteger", ADOX.DataTypeEnum.adInteger, 10); 
        try
        {
            cat.Create("Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=d:/m2.accdb;" + "Jet OLEDB:Engine Type=5");
            cat.Tables.Append(table);
            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.Oledb.4.0;" + "Data Source=d:/m2.accdb");
           conn.Open();
                 OleDbCommand cmd = new OleDbCommand();
                 cmd.Connection = conn;
                 cmd.CommandText = "INSERT INTO Table1
