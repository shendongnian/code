     foreach (var currRow in dataSet.Tables[0].Rows)
        {
                var tuple = Com.Tibco.As.Space.Tuple.Create();
    
                for (int i = 0; i < currRow.Values.Length; i++)
                {
                    var obj = dataSet.Tables[0].ColumnNames[i], currRow.Values[i];
                    var value = null;
                    value = obj as double;
                    if (!validObject(value)) value as string;
                    if (!validObject(value)) value as DateTime;
                    tuple.Put(value);
                }
    
                inSpace_.Put(tuple);
        }
    
       bool validObject(object obj) { return (null != obj); }
