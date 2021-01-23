    IList<DynamicColumn> idynamicttableColumns = new List<DynamicColumn>();
    
    for (int i = 0; i < attributeresult.Count(); i++)
    {
        DynamicColumn dynamictableColumns = new DynamicColumn();
        dynamictableColumns.Name = attributeresult.ElementAt(i).AttributeName;
        dynamictableColumns.Type = attributeresult.ElementAt(i).AttributeSqlType;
        dynamictableColumns.IsNullable = false;
        idynamicttableColumns.Add(dynamictableColumns);
    }
