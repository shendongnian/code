    private void CreateNewDataRow()
    {
        // Use the MakeTable function below to create a new table.
        DataTable table;
        table = MakeNamesTable();
        // Once a table has been created, use the  
        // NewRow to create a DataRow.
        DataRow row;
        row = table.NewRow();
        // Then add the new row to the collection.
        row["fName"] = "John";
        row["lName"] = "Smith";
        table.Rows.Add(row);
        foreach (DataColumn column in table.Columns)
        {
            Console.WriteLine(column.ColumnName);
        }
        SimpleDataGrid.DataContext = table;
    }
