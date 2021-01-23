    IList<DynamicColumn> idynamicttableColumns = new List<DynamicColumn>();
    int count = attributeresult.Count();
    for (int i = 0; i < count; i++)
    {
        var item = attributeresult.ElementAt(i);
        DynamicColumn dynamictableColumns = new DynamicColumn();
        dynamictableColumns.Name = item .AttributeName;
        dynamictableColumns.Type = item .AttributeSqlType;
        dynamictableColumns.IsNullable = false;
        idynamicttableColumns.Add(dynamictableColumns);
    }
