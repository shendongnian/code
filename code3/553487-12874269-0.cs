    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listView1.MouseDown += new MouseEventHandler(listView1_MouseDown);
            listView1.MouseDoubleClick += new MouseEventHandler(listView1_MouseDoubleClick);
            this.Load += new EventHandler(Form1_Load);
        }
        void Form1_Load(object sender, EventArgs e)
        {
            this.SetupListview();
        }
        private void SetupListview()
        {
            ListView lv = this.listView1;
            lv.View = View.List;
            lv.Items.Add("John Lennon");
            lv.Items.Add("Paul McCartney");
            lv.Items.Add("George Harrison");
            lv.Items.Add("Richard Starkey");
        }
        void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = listView1.HitTest(e.X, e.Y);
            ListViewItem item = info.Item;
            if (item != null)
            {
                MessageBox.Show("The selected Item Name is: " + item.Text);
            }
            else
            {
                MessageBox.Show("No Item is selected");
            }
        }
        void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = listView1.HitTest(e.X, e.Y);
            ListViewItem item = info.Item;
            if (item != null)
            {
                this.textBox1.Text = item.Text;
            }
            else
            {
                this.textBox1.Text = "No Item is Selected";
            }
        }
    }
