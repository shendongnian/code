    public static DataTable ListToDataTable<T>(List<T> list)
        {
            DataTable dtToConvert = new DataTable();
            try
            {
                
            foreach (PropertyInfo info in typeof(T).GetProperties())
            {
                dtToConvert.Columns.Add(new DataColumn(info.Name, info.PropertyType));
            }
            foreach (T t in list)
            {
                DataRow row = dtToConvert.NewRow();
                foreach (PropertyInfo info in typeof(T).GetProperties())
                {
                    row[info.Name] = info.GetValue(t, null);
                }
                dtToConvert.Rows.Add(row);
            }
            
            } catch(Exception ex)
                {
                    
                }
            return dtToConvert;
        }
