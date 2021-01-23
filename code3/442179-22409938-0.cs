       public static DataTable ListToDataTable<T>(this IList<T> data)
            {
                DataTable dt = new DataTable();
                PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
                for (int i = 0; i < props.Count; i++)
                {
                    PropertyDescriptor prop = props[i];
                    dt.Columns.Add(prop.Name, prop.PropertyType);
                }
                object[] values = new object[props.Count];
                foreach (T t in data)
                {
                    for (int i = 0; i < values.Length; i++)
                    {
                        values[i] = props[i].GetValue(t);
                    }
                    dt.Rows.Add(values);
                }
                return dt;
            }
