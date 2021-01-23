    public partial class Form3 : Form, ICsvFileView
    {
        public Form3()
        {
            InitializeComponent();
        }
        bool ICsvFileView.EnableSelectCSVFilePath
        {
            get
            {
                return btnSelectCsvFilePath.Enabled;
            }
            set
            {
                btnSelectCsvFilePath.Enabled = value;
            }
        }
        bool ICsvFileView.EnableNumberOfColumns
        {
            get
            {
                return nudNumberOfColumns.Enabled;
            }
            set
            {
                nudNumberOfColumns.Enabled = value;
            }
        }
        bool ICsvFileView.EnableCurrencyPair
        {
            get
            {
                return cbCurrencyPair.Enabled;
            }
            set
            {
                cbCurrencyPair.Enabled = value;
            }
        }
    }
