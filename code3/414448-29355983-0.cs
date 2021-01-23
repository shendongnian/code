        protected IList<TResult> TableToList<TResult>(DataTable table) where TResult : new()
        {
            var result = new List<TResult>(table.Rows.Count);
            var fields = typeof(TResult).GetTypeInfo().DeclaredFields;
            TResult obj;
            Object colVal;
            var columns = table.Columns;
            var nullableTypeDefinition = typeof(Nullable<>);
            var dbNullType = typeof(DBNull);
            Type[] genericArguments;
            foreach (DataRow row in table.Rows)
            {
                obj = new TResult();
                foreach (var f in fields)
                {
                    if (columns.Contains(f.Name))
                    {
                        colVal = row[f.Name];
                        if (colVal.GetType() == f.FieldType)
                        {
                            f.SetValue(obj, colVal);
                        }
                        else if (colVal.GetType() != dbNullType && f.FieldType.IsGenericType && 
                                 f.FieldType.GetGenericTypeDefinition() == nullableTypeDefinition)
                        {
                                genericArguments = f.FieldType.GetGenericArguments();
                                if (genericArguments.Length > 0 && genericArguments[0] == colVal.GetType())
                                {
                                    f.SetValue(obj, colVal);
                                }
                        }
                    }
                }
                result.Add(obj);
            }
            return result;
        }
