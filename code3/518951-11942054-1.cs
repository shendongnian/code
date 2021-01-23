    public partial class Form1 : Form
    {
        private int i = 0;
        public Form1()
        {
            InitializeComponent();
            listView1.View = View.Details;
            listView1.Columns.Add("Col", 250);
            listView1.VirtualMode = true;
            listView1.RetrieveVirtualItem += listView1_RetrieveVirtualItem;
            listView1.VirtualListSize = 25;
            button1.Click += button1_Click;
        }
        private void listView1_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            e.Item = new ListViewItem((i + e.ItemIndex).ToString());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // simulate data update
            i += 10;
            //listView1.VirtualListSize += 5; // you can even change the virtual list size while keeping current scroll position
            listView1.Refresh();
        }
    }
