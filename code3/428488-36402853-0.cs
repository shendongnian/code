    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.SuspendLayout();
            for (int i = 1; i < 10000; i++)
            {
                dataGridView1.Rows.Add(i);                
            }
            dataGridView1.ResumeLayout();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
                row.HeaderCell.Value = (row.Index + 1).ToString();
        }
    }
