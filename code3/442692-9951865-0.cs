    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string[] row = { textBox1.Text, textBox2.Text, textBox3.Text };
            var listViewItem = new ListViewItem(row); 
            listView1.Items.Add(listViewItem);
        }
    }
