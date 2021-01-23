    public static void FillDataTable<T>(DataTable dt, List<T> items)
    {
        var propList = typeof(T).GetMembers(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
        foreach(T t in items)
        {
            var row = dt.NewRow();
            foreach(MemberInfo info in propList)
            {
                if (info is PropertyInfo)
                    row[info.Name] = (info as PropertyInfo).GetValue(t, null);
                else if (info is FieldInfo)
                    row[info.Name] = (info as FieldInfo).GetValue(t);
            }
            dt.Rows.Add(row);
        }
    }
