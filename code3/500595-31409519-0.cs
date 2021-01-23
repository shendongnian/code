    public List<T> Select<T>(string filterParam)
    {    
        DataTable dataTable = new DataTable()
        
        //{... implement filter to fill dataTable }
        
        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row;
        
        foreach (DataRow dr in dataTable.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dataTable.Columns)
            {
                row.Add(col.ColumnName, dr[col]);
            }
            rows.Add(row);
        }
        
        string json = new JavaScriptSerializer().Serialize(rows);
        
        using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
        {
            DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(T[]));
            var tick = (T[])deserializer.ReadObject(stream);
            return tick.ToList();
        }
    }
