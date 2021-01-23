    // Query for UserDefined objects to just filter to your own objects. All will
    // include system objects (references to objects in master.dacpac if you reference that
    // and BuiltIn objects such as the data types. You probably don't care about those
    var allTables = model.GetObjects(DacQueryScopes.UserDefined, Table.TypeClass);
    foreach (var table in allTables)
    {
        writter.WriteLine(table.Name);
        // Columns are referenced by tables, so GetReferenced can be used. The GetChildren can also be used 
        // but filtering by comparing "child.ObjectType == Column.TypeClass" would simplify your example
        foreach (var column in table.GetReferenced(Table.Columns))
        {
            // Now you can use the Column metadata class's properties to query your Column object
            bool isNullable = column.GetProperty<bool>(Column.Nullable); 
            SqlDataType sdt = column.GetReferenced(Column.DataType).First().GetProperty<SqlDataType>(DataType.SqlDataType);
        }
 
