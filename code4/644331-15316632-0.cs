    [DataContract(Name="ReportDTO", Namespace="http://chasmx/2013/2")]
    public sealed class ReportDTO
    {
        /// <summary>
        /// Filename to save the report attached in <see cref="@Report"/> under.
        /// </summary>
        [DataMember]
        public String FileName { get; set; }
        /// <summary>
        /// Report as a byte array.
        /// </summary>
        [DataMember]
        public byte[] @Report { get; set; }
        /// <summary>
        /// Mimetype of the report attached in <see cref="@Report"/>. This can be used to launch the application registered for this mime type to view the saved report.
        /// </summary>
        [DataMember]
        public String MimeType { get; set; }
    }
    public void ViewReport()
    {
        ServiceContracts.DataContract.ReportDTO report;
        String filename;
        
        this.Cursor = Cursors.Wait;
        try
        {
            // Download the report.
            report = _reportService.GetReport(this.SelectedReport.ID);
            // Save the report in the temporary directory
            filename = Path.Combine(Path.GetTempPath(), report.FileName);
            try
            {
                File.WriteAllBytes(filename, report.Report);
            }
            catch (Exception e)
            {
                string detailMessage = "There was a problem saving the report as '" + filename + "': " + e.Message;
                _userInteractionService.AskUser(String.Format("Saving report to local disk failed."), detailMessage, MessageBoxButtons.OK, MessageBoxImage.Error);
                return;
            }
        }
        finally
        {
            this.Cursor = null;
        }
        System.Diagnostics.Process.Start(filename); // The OS will figure out which app to open the file with.
    }
