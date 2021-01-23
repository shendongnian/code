    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private delegate void InsertIntoListDelegate(string email);
        public void InsertIntoList(string email)
        {
            if(InvokeRequired)
            {
                Invoke(new InsertIntoListDelegate(InsertIntoList), email);
            }
            else
            {
                listView1.Items.Add(email);
            }
        }
        private void button1_Click(object sender, System.EventArgs e)
        {
            Task.Factory.StartNew(() => InsertIntoList("test"));
        }
    }
