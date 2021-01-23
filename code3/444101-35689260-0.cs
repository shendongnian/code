    public Form1()
        {
            InitializeComponent();
            DataTable dt = new DataTable();
            dt.Columns.Add("Column1");
            dt.Columns.Add("Column2");
            dt.Rows.Add(dt.NewRow());
            dataGridView1.DataSource = dt;
            
            dataGridView1.AllowUserToAddRows = false;
        }
    
        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
        }
    
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //instead of MessageBox there could be as well your check conditions
            if (MessageBox.Show("Cell edit finished, add a new row?", "Add new row?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                dataGridView1.AllowUserToAddRows = true;
            else dataGridView1.AllowUserToAddRows = false;
        }
