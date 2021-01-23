     DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds.ReadXml(Server.MapPath("~/XMLFile.xml"));
            dt = ds.Tables[5];
    
            var query = from s in dt.AsEnumerable()
                        group s by s.Field<string>("id") into g
                        select new { id = g.Key, field_text = g.ToList(),Count=g.ToList().Count };
    
    
            DataTable dt1 = new DataTable();
            int maxRowid=0;
            foreach (var obj in query)
            {
                dt1.Columns.Add(obj.id);
                if(obj.Count>maxRowid)
                {
                    maxRowid=obj.Count;
                }
    
            }
    
            // Add Rows to table         
            for (int count = 0; count < maxRowid; count++)
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
