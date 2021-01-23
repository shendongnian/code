    public partial class Form1 : ReportForm
    {
        public Form1()
        {
            // Wire up the report used by the Visual Studio-designed report viewer to the base class
            base.WinFormReport = reportViewer1.LocalReport;
            InitializeComponent();
        }
        // The search parameters will be different for every winform, and will presumably
        //  come from some winform UI elements on that form, e.g., parentPartTextBox.Text
        protected override DataResult GetReportData(SubreportProcessingEventArgs e)
        {
            // Return the data result, which contains a data table and a label which will be
            //  passed to the report data source
            // You could use DataSet in DataResult instead of DataTable if needed
            switch (e.ReportPath)
            {
                case "rptSubAlternateParts":
                    return new DataResult(
                        new BLL.AlternatePartBLL().GetAlternativePart(parentPartTextBox.Text)
                        , "BLL_AlternatePartBLL"
                    );
                case "rptSubGetAssemblies":
                    return new DataResult(
                        new BLL.SubAssemblyBLL().GetSubAssemblies(someOtherTextBox.Text)
                        , "BLL_SubAssemblyBLL"
                    );
                default:
                    throw new NotImplementedException(string.Format("Subreport {0} is not implemented", e.ReportPath));
            }
        }
                                    .
                                    .
                                    .
