    public partial class main : Form
    {
        login log = new login();
        public main()
        {
            InitializeComponent();
            log.sendString += new login.sendStringDelegate(setString);
        }
    
        public void setString(string s)
        {
            whatever.text = s;
        }
    
        public string username
        {
            set { toolStripLabel1.Text = value; }
        }
        private void main_Load(object sender, EventArgs e)
        {
            Form home = new home();
            home.MdiParent = this;
            home.WindowState = FormWindowState.Maximized;
            home.Show();
        }
    }
