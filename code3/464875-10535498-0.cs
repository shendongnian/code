    private DataTable GetData(string tableName)
        {
            DataSet ds = new DataSet();
            string query = "Select * from something";
            OdbcDataAdapter da = new OdbcDataAdapter(query, conn);
            da.Fill(ds);
            DataTable dt = ds.Tables[tableName];
            return dt;
        }
    //You can fill the dataset once and then just get the table by table name. No necessary that you have to fill the dataset every time to get tables 
        private void RunReportViewer()
        {
            this.ReportViewer1.Reset();
            this.ReportViewer1.LocalReport.ReportPath = Server.MapPath("Report.rdlc");
            ReportDataSource rds = new ReportDataSource("#_your_table_Name", GetData());
            this.ReportViewer1.LocalReport.DataSources.Clear();
            this.ReportViewer1.LocalReport.DataSources.Add(rds);
            this.ReportViewer1.DataBind();
            this.ReportViewer1.LocalReport.Refresh();
        }
