    public partial class MainForm : Form
    {        
        public CoreWrapper _icCore;        
        private Dictionary<string, int> audioDevices;
    
        #region MainForm Ctor
    
        public MainForm()
        {
            InitializeComponent();
            _icCore.Start();
        }
        private void MainForm_Load(object sender, System.EventArgs e)
        {
            form1.MyParentForm = this;
            form1.Show();
        }
    
        public Form1 form1 = new Form1();
    }
