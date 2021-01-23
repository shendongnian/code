    public partial class login : Form
    {
        public delegate void sendStringDelegate(string s);
        public event sendStringDelegate sendString;
    
        public login()
        {
            InitializeComponent();
        }
    
        public string username
        {
            get{
                return a.ToString();}
        }
    
        public string a;
    
        private void button1_Click(object sender, EventArgs e)
        {
            a = comboBox1.Text;
            sendString(a);
         // rest is the code for login.
        }
    }
