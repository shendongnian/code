    public partial class frmLoadACTFCST : Form
    {
        public frmLoadACTFCST()
        {
            InitializeComponent();
            actfcst = ACTFCST.ACT;
            btnActual.Tag = ACTFCST.ACT;
            btnActual.Checked = true;
            btnForecast.Tag = ACTFCST.FCST; 
            btnPlan.Tag = ACTFSCT.PLAN;
            btn5YrPlan2012.Tag = ACTFCST.FiveYearPlan2012;
        }
        public enum ACTFCST
        {
            ACT = 1,
            FCST = 2,
            PLAN = 3,
            FiveYearPlan2012=4
        }
        public static ACTFCST actfcst { get; private set; }
        private void CheckedChanged(object sender, EventArgs e)
        {
            // All the buttons uses this Click-event.
            actfcst = (sender as Button).Tag as ACTFCST;
        }
        private void btnContinue_Click(object sender, EventArgs e)
        {
            MessageBox.Show(actfcst.ToString());
            Close();
        }
    }
