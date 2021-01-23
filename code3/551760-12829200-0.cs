    GenerateDataTable(typeof(Rule));
    private DataTable GenerateRulesDataTable(Type type)
    {
        DataTable table = new DataTable();
        // build table columns
        foreach (PropertyInfo propInfo in type.GetProperties())
        {
            Type colType = Nullable.GetUnderlyingType(propInfo.PropertyType) ?? propInfo.PropertyType;
            DataColumn col = new DataColumn(propInfo.Name, colType);
            table.Columns.Add(col);
        }
        return table;
    }
