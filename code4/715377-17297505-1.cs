    private DataTable MakeNamesTable()
    {
        // Create a new DataTable titled 'Names.'
        DataTable namesTable = new DataTable("Names");
        // Add three column objects to the table.
        DataColumn idColumn = new DataColumn();
        idColumn.DataType = System.Type.GetType("System.Int32");
        idColumn.ColumnName = "id";
        idColumn.AutoIncrement = true;
        namesTable.Columns.Add(idColumn);
        DataColumn fNameColumn = new DataColumn();
        fNameColumn.DataType = System.Type.GetType("System.String");
        fNameColumn.ColumnName = "Fname";
        fNameColumn.DefaultValue = "Fname";
        namesTable.Columns.Add(fNameColumn);
        DataColumn lNameColumn = new DataColumn();
        lNameColumn.DataType = System.Type.GetType("System.String");
        lNameColumn.ColumnName = "LName";
        namesTable.Columns.Add(lNameColumn);
        // Create an array for DataColumn objects.
        DataColumn[] keys = new DataColumn[1];
        keys[0] = idColumn;
        namesTable.PrimaryKey = keys;
        // Return the new DataTable. 
        return namesTable;
    }
