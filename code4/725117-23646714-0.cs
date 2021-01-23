    SqlConnection con = new SqlConnection(“Connection String “);
    protected void Page_Load(object sender, EventArgs e)
    {
    con.Open();
    ReportDocument rpt = new ReportDocument();
    rpt.Load(Server.MapPath("~/CrystalReport.rpt"));
    SqlCommand cmd = new SqlCommand("Select * from Raj_Table[tbl_name]", con);
    SqlDataAdapter da = new SqlDataAdapter();
    DataSet ds = new DataSet();
    da.SelectCommand = cmd;
    da.Fill(ds, "Raj_Table[TableName]");
    rpt.SetDataSource(ds);
    con.Close();
    CrystalReportViewer1.ReportSource = rpt;
    CrystalReportViewer1.DataBind();
    }
}
