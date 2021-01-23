    public string GetJson(DataTable dt)
    {
      System.Web.Script.Serialization.JavaScriptSerializer serializer = new  System.Web.Script.Serialization.JavaScriptSerializer();
      List<Dictionary> rows = new List<Dictionary>();
      Dictionary row = null;
 
      foreach (DataRow dr in dt.Rows) {
       row = new Dictionary();
       foreach (DataColumn col in dt.Columns) {
         row.Add(col.ColumnName, dr[col]);
       }
       rows.Add(row);
     }
     return serializer.Serialize(rows);
     }
 
