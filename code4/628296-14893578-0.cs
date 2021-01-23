    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            var lines = System.IO.File.ReadAllLines("TextFile.txt");
            DataTable dt = new DataTable();
            dt.Columns.Add("key");
            dt.Columns.Add("value");
            foreach (string line in lines)
            {
                var key = line.Split(',')[0];
                var value = line.Split(',')[1];
                dt.Rows.Add(key, value);
            }
            dt.DefaultView.Sort="key";
            dataGridView1.DataSource = dt;
        }
    }
