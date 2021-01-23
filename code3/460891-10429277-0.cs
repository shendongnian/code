    public static DataTable CreateDataTable<T>()
    {
        var dt = new DataTable();
    
        var propList = typeof(T).GetMembers(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
    
        foreach(MemberInfo info in propList)
        {
            if(info is PropertyInfo)
                dt.Columns.Add(new DataColumn(info.Name, (info as PropertyInfo).PropertyType));
            else if(info is FieldInfo)
                dt.Columns.Add(new DataColumn(info.Name, (info as FieldInfo).FieldType));
        }
    
        return dt;
    }
