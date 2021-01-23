    // Add this event handler to the DataGridView
    private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        dgv.BindingContext[dgv.DataSource].EndCurrentEdit();
    }
    // Somewhere else (most likely in Designer.cs) ...
    private DataGridView dgv;
    private Form1()
    {
       dgv.CellEndEdit += dgv_CellEndEdit;
       var table = new DataTable();
       // ... fill the table ...
       dgv.DataSource = table;
    }
