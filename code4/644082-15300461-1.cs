    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 9; i++)
            {
                listView1.Items.Add("kashif");
            }
            button1.Enabled = false;            
        }
        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            button1.Enabled = listView1.SelectedItems.Count > 0;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem v in listView1.SelectedItems)
            {
                v.Remove();
            }
        }
    }
