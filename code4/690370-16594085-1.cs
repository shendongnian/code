    public partial class Form1 : Form
    {
        Menu menuMaker = new Menu();
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            listView.Clear();
            if (checkBox1.Checked)
            {
               listView.Items.Add(menuMaker.GetMenuItem(0));
            }
            if (checkBox2.Checked)
            {
               listView.Items.Add(menuMaker.GetMenuItem(1));
            }
        }
    }
