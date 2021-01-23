    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Load += new EventHandler(Form1_Load);
        }
        void Form1_Load(object sender, EventArgs e)
        {
            Form2 myDialog = new Form2();
            if (myDialog.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
            {
                // failed login
                // exit application
            }
            // all good, continue
        }
    }
