            /// <summary>
            /// Converts IList object to Datatable
            /// </summary>
            /// <typeparam name="T"> name of the class - List Type</typeparam>
            /// <param name="pList"> IList object</param>
            /// <returns>Datatable</returns>
            public static DataTable ConvertTo<T>(IList<T> pList)
            {
                DataTable table = CreateTable<T>();
                Type entityType = typeof(T);
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);
    
                foreach (T item in pList)
                {
                    DataRow row = table.NewRow();
    
                    foreach (PropertyDescriptor prop in properties)
                    {
                        row[prop.Name] = prop.GetValue(item);
                    }
                    table.Rows.Add(row);
                }
    
                return table;
            }
