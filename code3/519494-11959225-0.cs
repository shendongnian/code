    public partial class RowContent : UserControl
    {
        public RowContent()
        {
            InitializeComponent();
        }
        public string SetChkBox1Text
        {
            set { stprIndex_chkBox.Text = value; }
        }
        public bool IsEnabledChecked
        {
            get { return enable_chkBox.Checked; }
        }
    }
