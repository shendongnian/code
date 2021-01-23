          private static List<Type> Types
        {
            get
            {
                return new List<Type>
                       {
                           typeof (String),
                           typeof (int?),
                           typeof (Guid?),
                           typeof (double?),
                           typeof (decimal?),
                           typeof (float?),
                           typeof (Single?),
                           typeof (bool?),
                           typeof (DateTime?),
                           typeof (int),
                           typeof (Guid),
                           typeof (double),
                           typeof (decimal),
                           typeof (float),
                           typeof (Single),
                           typeof (bool),
                           typeof (DateTime),
                           typeof (DBNull)
                       };
            }
        }
     public static DataTable ToDataTable<T>(this IEnumerable<T> source)
        {
            using (var dt = new DataTable())
            {
                var toList = source.ToList();
                for (var index = 0; index < typeof(T).GetProperties().Count(); index++)
                {
                    var info = typeof(T).GetProperties()[index];
                    if (Types.Contains(info.PropertyType))
                    {
                        dt.Columns.Add(new DataColumn(info.Name, info.PropertyType));
                    }
                }
                for (var index = 0; index < toList.Count; index++)
                {
                    var t = toList[index];
                    var row = dt.NewRow();
                    foreach (var info in typeof(T).GetProperties())
                    {
                        if (Types.Contains(info.PropertyType))
                        {
                            row[info.Name] = info.GetValue(t, null);
                        }
                    }
                    dt.Rows.Add(row);
                }
                return dt;
            }
        }
