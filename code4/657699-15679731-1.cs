    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            radGridView1.Columns.Add(new GridViewCheckBoxColumn() { Name = "CheckBoxCol" });
            radGridView1.Rows.Add(false);
            radGridView1.Rows.Add(true);
            radGridView1.Rows.Add(false);
            radGridView1.Rows.Add(true);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (GridViewRowInfo row in radGridView1.Rows)
            {
                Console.WriteLine(row.Cells["CheckBoxCol"].Value);
            }
        }
    }
