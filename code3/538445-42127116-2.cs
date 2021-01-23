    private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        dgv.BindingContext[dgv.DataSource].EndCurrentEdit();
    }
    // Somewhere else:
    private DataGridView dgv;
    private Form1()
    {
       dgv.DataSource = new DataTable();
       dgv.CellEndEdit += dgv_CellEndEdit;
    }
