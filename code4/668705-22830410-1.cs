    DataTable dataTable = new DataTable();
                List<MemberInfo> props = typeof(T).GetFields().Select(objField => (MemberInfo)objField).ToList();
                props.AddRange(typeof(T).GetProperties().Select(objField => (MemberInfo)objField));
    
                if (props.Count > 0)
                {
                    Type t;
                    bool tIsField = false;
                    for (int iCnt = 0; iCnt < props.Count; iCnt++)
                    {
                        var prop = props[iCnt];
                        tIsField = prop.MemberType == MemberTypes.Field;
                        dataTable.Columns.Add(prop.Name, tIsField ? ((FieldInfo)prop).FieldType : ((PropertyInfo)prop).PropertyType);
                    }
                    foreach (T item in data)
                    {
                        DataRow dr = dataTable.NewRow();
    
                        foreach (var field in props)
                        {
                            tIsField = field.MemberType == MemberTypes.Field;
                            object value = tIsField ? ((FieldInfo)field).GetValue(item) : ((PropertyInfo)field).GetValue(item, null);
                            dr[field.Name] = value;
                        }
                        dataTable.Rows.Add(dr);
                    }
                }
                return dataTable;
