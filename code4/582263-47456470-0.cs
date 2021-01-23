    public DataTable JoinTable(DataTable piTable1, string table1Column, 
    DataTable piTable2, string table2Column)
    {
         DataTable JoinTable = new DataTable();
         JoinTable.Columns.Add(table1Column);
         JoinTable.Columns.Add(table2Column);
            if (piTable1 == null || piTable2 == null)
                return new DataTable();
            var q = from parent in piTable1.AsEnumerable()
                    from child in piTable2.AsEnumerable()
                    select new
                    {
                        table1Column = parent.Field<string>(table1Column),
                        table1Column = child.Field<string>(table2Column),
                    };
            JoinTable = ToDataTable((q.ToArray()).ToList());
            JoinTable.TableName = "ResultTable";
            return JoinTable;
            
        }
        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
