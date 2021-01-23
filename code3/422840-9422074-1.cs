      public static DataTable GencoUpload(string filepath) 
      { 
            DataTable dt = new DataTable(); 
    
            using(StreamReader sr = new StreamReader(filepath))
            { 
                string line = sr.ReadLine(); 
                string[] value = line.Split('|'); 
            
                DataRow row; 
     
                foreach (string dc in value) 
                { 
                    dt.Columns.Add(new DataColumn(dc)); 
                } 
     
                while (!sr.EndOfStream) 
                { 
                    value = sr.ReadLine().Split('|'); 
                    if (value.Length == dt.Columns.Count) 
                    { 
                        row = dt.NewRow(); 
                        row.ItemArray = value; 
                        dt.Rows.Add(row); 
                    } 
                }
            }
    
            return dt; 
        } 
