    public partial class Dynamic : UserControl, IData
    {
        public Dynamic()
        {
            InitializeComponent();
        }
        public string PilotName
        {
            get { return txtName.Text; }
        }
        public string Ship
        {
            get { return txtShip.Text; }
        }
        public DateTime StartTime
        {
            get { return Convert.ToDateTime(txtStart.Text); }
        }
        public DateTime EndTime
        {
            get { return Convert.ToDateTime(txtEnd.Text); }
        }
        public decimal Rate
        {
            get { return Convert.ToDecimal(txtPayRate.Text); }
        }
    }
