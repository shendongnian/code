        string strConnectionString = "Data Source=(local);Initial Catalog=Projects_DB;Integrated Security=True";
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand("sp_GetProject " + "'0660CAD6-6F1A-4D19-A1FD-17BF3655AC98'");
        cmd.CommandType = CommandType.Text;
        cmd.Connection = new SqlConnection (strConnectionString);
        da.SelectCommand = cmd;
        da.Fill(ds,"DataSet1");
        reportViewer1.ProcessingMode = ProcessingMode.Local;
        ReportDataSource source = new ReportDataSource();
        reportViewer1.LocalReport.DataSources.Clear();
        reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", ds.Tables[0]));
        reportViewer1.LocalReport.Refresh();
        reportViewer1.RefreshReport();
