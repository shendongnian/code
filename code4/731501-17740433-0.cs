    public partial class Form3 : Form
    {
        int _port;
        public int Port
        {
           get { return _port; }
           set { _port = value; }
        }
    }
    
    public partial class Form1 : Form
    {
        public Form1()
        {
           InitializeComponent();
        }
        
        void menu1_Click(object sender, EventArgs e)
        {
            Form2 frq = new Form2();
            frq.Show();
            Form3 frm3 = new Form3();
            frm3.Port = 8080;
        
            MessageBox.Show("{0} server is online ", frm3.Port);
        }
        
    }
