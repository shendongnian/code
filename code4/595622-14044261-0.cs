    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //dataGridView1.ReadOnly = true;
            string[] row1 = new string[] { "test", "test1" };
            string[] row2 = new string[] { "test2", "test3" };
            string[] row3 = new string[] { "test4", "test5" };
            dataGridView1.Columns.Add("1", "1");
            dataGridView1.Columns.Add("2", "2");
            dataGridView1.Rows.Add(row1);
            dataGridView1.Rows.Add(row2);
            dataGridView1.Rows.Add(row3);
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.ReadOnly = true;
            }
            dataGridView1.Rows[1].ReadOnly = false;
        }
    }
