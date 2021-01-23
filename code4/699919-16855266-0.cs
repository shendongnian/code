    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();            
        }
        public MainForm MyParentForm { get; set; }       
        private void button1_Click(object sender, EventArgs e)
        {
            string dial = Registry.CurrentUser.OpenSubKey("SOFTWARE").OpenSubKey("CS").GetValue("DIAL").ToString();
            // Use the reference to MyParentForm
            MyParentForm.txtSendKeys.Text = "esdcze";
        }        
    }
