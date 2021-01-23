    protected void Page_Load(object sender, EventArgs e)
     {
      DataTable dtDocOperations = new DataTable();
      dtDocOperations.Columns.Add("ButtonRole");
      dtDocOperations.Columns.Add("OperattionCode");
      dtDocOperations.Rows.Add(new Object[] { "MR", "V" });
      dtDocOperations.Rows.Add(new Object[] { "MR", "A" });
      dtDocOperations.Rows.Add(new Object[] { "MR", "R" });
      Session["DocOperattions"] = dtDocOperations;
      dtDocOperations.AcceptChanges(); // once AcceptChanges called then you can get the modified rows
    
      dtDocOperations.Rows[0]["ButtonRole"] = "mr1";
      DataTable dt = dtDocOperations.GetChanges(DataRowState.Modified);
     }
 
