    protected void Page_Load(object sender, EventArgs e)
    {
      var DistinctByIdColumn = getDT2().AsEnumerable()
                                       .DistinctBy(
                                       row => new { Id = row["Id"] });
      DataTable dtDistinctByIdColumn = DistinctByIdColumn.CopyToDataTable();
    }
        
        
    public DataTable getDT2()
    {
       DataTable dt = new DataTable();
       dt.Columns.Add("Id", typeof(string));
       dt.Columns.Add("Name", typeof(string));
       dt.Columns.Add("Dob", typeof(string));
       dt.Rows.Add("1", "aa","1.1.11");
       dt.Rows.Add("2", "bb","2.3.11");
       dt.Rows.Add("2", "cc","1.2.12");
       dt.Rows.Add("3", "cd","2.3.12");
       return dt;
    }
