    public static IList<T> ConvertTo<T>(IList<DataRow> rows)
        {
            IList<T> list = null;
    
            if (rows != null)
            {
                list = new List<T>();
    
                foreach (DataRow row in rows)
                {
                    T item = CreateItem<T>(row);
                    list.Add(item);
                }
            }
    
            return list;
        }
