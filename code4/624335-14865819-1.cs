    /// <summary>
    /// Don't cut & paste into any Windows Forms, inherit the behavior you want from a base class
    /// </summary>
    public abstract class ReportForm : System.Windows.Forms.Form
    {
        // I'm not sure exactly what this is used for, but I put it in base class in case there is some use for it here
        protected string _commonSubreportKey = "12345";
        // This will be the one line of code needed in each WinForm--providing the base class a reference
        //  to the report, so it has access to the SubreportProcessing event
        protected Report WinFormReport { get; set; }
        // Making this abstract requires each derived WinForm to implement GetReportData--foolproof!
        protected abstract DataResult GetReportData(SubreportProcessingEventArgs e);
        
        // Wire up the subreport_processing handler when any WinForm loads
        // You could override this in derived WinForms classes if you need different behavior for some WinForms,
        //  but I would bet this default behavior will serve well in most or all cases
        protected virtual void Form1_Load(object sender, EventArgs e)
        {
            Report.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing);
        }
        // When the Subreport processing event fires, handle it here
        // You could also override this method in a derived class if need be
        protected virtual void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            // Get the data needed for the subreport
            DataResult dataResult = this.GetReportData(e);
            e.DataSources.Clear();
            e.DataSources.Add(new ReportDataSource(dataResult.Label, dataResult.Table));
        }
    }
