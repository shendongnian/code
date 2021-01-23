    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        txtCveMun.Text = dataGridView1.Rows[e.RowIndex].Cells["gridViewColumnName1"].Value.ToString();
        txtSomeControl.Text = dataGridView1.Rows[e.RowIndex].Cells["gridViewColumnName2"].Value.ToString();    
    }
