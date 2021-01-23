     private string DataTableToJson(DataTable dt) {
      if (dt == null) {
       return "[]";
      };
      if (dt.Rows.Count < 1) {
       return "[]";
      };
    
      JArray array = new JArray();
      foreach(DataRow dr in dt.Rows) {
       JObject item = new JObject();
       foreach(DataColumn col in dt.Columns) {
        item.Add(col.ColumnName, dr[col.ColumnName]?.ToString());
       }
       array.Add(item);
      }
    
      return array.ToString(Newtonsoft.Json.Formatting.Indented);
     }
