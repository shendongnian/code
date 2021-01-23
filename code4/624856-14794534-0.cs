    public partial class ThisAddIn
    {
    public DataTable GetDetails()
      {
      // Some Codes here
        DataTable dt = new DataTable();
        dt.Columns.Add("id");
        dt.Columns.Add("uid");
        dt.Columns.Add("email");
        DataRow row = dt.NewRow();    
         row["id"] = sid;
         sid++;    
         row["uid"] = uid;
         row["email"] = e;
         dt.Rows.Add(row);
         return dt;
      }
    }
