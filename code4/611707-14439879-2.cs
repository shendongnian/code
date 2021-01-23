    public Form1()
    {
        InitializeComponent();
        dataGridView1.DataSource = new[] { new { Id = 1 }, new { Id = 10 } };
        dataGridView2.DataSource = new[] { new { Id = 2 }, new { Id = 20 } };
        dataGridView3.DataSource = new[] { new { Id = 3 }, new { Id = 30 } };
    }
    private void showSelectedRowToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var dgv = tabControl1.SelectedTab.Controls.OfType<DataGridView>().FirstOrDefault();
        if(dgv != null)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                // I'm using MessageBox to show the index of the row. 
                // You should add your Modify / Delete logic
                MessageBox.Show(dgv.SelectedRows[0].Index.ToString());
            }
        }
    }
