// create SqlConnection
        SqlConnection myConnection = new SqlConnection(ConnectionString);
        myCommand.Connection = myConnection;
        SqlDataAdapter da = new SqlDataAdapter(myCommand);
        //get the data
        DataSet data = new DataSet();
        da.Fill(data);
        if (data != null && data.Tables.Count > 0 && data.Tables[0].Rows.Count > 0)
        {
            ReportingServicesReportViewer.Visible = true;
            ltrStatus.Text = string.Empty;
            //provide local report information to viewer
            ReportingServicesReportViewer.LocalReport.ReportPath = Server.MapPath(Report.RDLCPath);
            //bind the report attributes and data to the reportviewer
            ReportDataSource rds = new ReportDataSource("DataSet1", data.Tables[0]);
            ReportingServicesReportViewer.LocalReport.DataSources.Clear();
            ReportingServicesReportViewer.LocalReport.DataSources.Add(rds);
            ReportingServicesReportViewer.LocalReport.Refresh();
        }
        else
        {
            ReportingServicesReportViewer.Visible = false;
            ltrStatus.Text = "No data to display.";
        }
