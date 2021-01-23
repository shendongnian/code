    System.Web.Script.Serialization.JavaScriptSerializer serializer = new 
    System.Web.Script.Serialization.JavaScriptSerializer();
            
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            foreach (DataRow dr in DsCnx.Tables[0].Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in DsCnx.Tables[0].Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }
            SerialData= serializer.Serialize(rows);
           PostRequest("http://localhost:53922/api/Demo", SerialData);
