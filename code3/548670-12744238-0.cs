      DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        ds.ReadXml(Server.MapPath("~/XMLFile.xml"));
        dt = ds.Tables[5];
      
        var query = from s in dt.AsEnumerable()
                    group s by s.Field<string>("id") into g
                    select new { id = g.Key, field_text = g.ToList() };
    
    
        DataTable dt1 = new DataTable();
        foreach (var obj in query)
        {
            dt1.Columns.Add(obj.id);
        }
        foreach (object col in dt1.Columns)
        {
            dt1.Rows.Add("", "");             
        }
    
        int i = 0;      
        foreach (var obj in query)
        {
            int j = 0;     
            foreach (var dr in obj.field_text)
            {
                dt1.Rows[j][i] = ((DataRow)dr)["field_text"];
                j++;               
            }
            i++;
             
        }
