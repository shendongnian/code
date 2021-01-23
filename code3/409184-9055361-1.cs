    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            // Load a sample report:
            ReportDocument doc = new ReportDocument();
            doc.Load(@"C:\Temp\test.rpt");
            reportViewer.ReportSource = doc;
        }
        private void OnReportRefresh(object source, CrystalDecisions.Windows.Forms.ViewerEventArgs e)
        {
            MessageBox.Show("Refresh clicked!");
        }
    }
