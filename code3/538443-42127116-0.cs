    private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        dgv.BindingContext[dgv.DataSource].EndCurrentEdit();
    }
    // Somewhere else:
    //   DataGridView dgv;
    //   dgv.DataSource = new DataTable();
    //   dgv.CellEndEdit += dgv_CellEndEdit;
