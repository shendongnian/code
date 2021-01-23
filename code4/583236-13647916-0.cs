        protected void btnCreate_Click(object sender, System.EventArgs e)
        {
            if (ddlExportFormat.SelectedIndex != 0)
            {
                ExportReport(ddlExportFormat.SelectedValue);
                btnShow_Click(sender, e);
            }
        }
        private void ExportReport(String format)
        {
            // Variables
            Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;
            string fileName = _reportName +"_"+ DateTime.Now.ToString("yyyyMMdd HH:mm"); 
            // Setup the report viewer object and get the array of bytes
            ReportViewer viewer = new ReportViewer();
            viewer.ProcessingMode = ProcessingMode.Local;
            viewer.ServerReport.ReportServerUrl = new System.Uri(_reportServerUrl);
            viewer.ServerReport.ReportPath = _reportPath;
            if (this.PrepareReportParameters())
            {
                viewer.ServerReport.SetParameters(lstReportParameters);
            }
            byte[] bytes = viewer.ServerReport.Render(format, null, out mimeType, out encoding, out extension, out streamIds, out warnings);
            // Now that you have all the bytes representing the PDF report, buffer it and send it to the client.
            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = mimeType;
            Response.AddHeader("content-disposition", "attachment; filename=" + fileName + "." + extension);
            Response.BinaryWrite(bytes); // create the file
            Response.Flush(); // send it to the client to download
        }
