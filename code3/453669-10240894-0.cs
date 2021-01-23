    public partial class MainForm : Form
    {
            public MainForm()
            {
                InitializeComponent();
            }
        private void button1_Click(object sender, EventArgs e)
        {
            Panel formPanel = new Panel();
            formPanel.OnPanelClick += new Panel.OnPanelButtonClick(formPanel_OnPanelClick);
            formPanel.Show();
        }
        void formPanel_OnPanelClick(string a)
        {
            MessageBox.Show(a);
        }
    }
    public partial class Panel : Form
    {
        public delegate void OnPanelButtonClick(string a);
        public event OnPanelButtonClick OnPanelClick = null;
        public Panel()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (OnPanelClick != null)
            {
                OnPanelClick("from Panel.cs");
            }
        }
    }
