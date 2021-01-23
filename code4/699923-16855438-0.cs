    public partial class MainForm : Form
    {
        public CoreWrapper _icCore;
        private Dictionary<string, int> audioDevices;
        public MainForm()
        {
            InitializeComponent();
            _icCore.Start();
            // sets the form1's owner form to the MainForm instance
            form1.Owner = this;
            // show the Form1 form
            form1.Show();
        }
        public Form1 form1 = new Form1();
        internal void SetSendKeys(string value)
        {
            txtSendKeys.Text = value;
        }
    }
