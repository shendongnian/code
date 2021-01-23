    private void EditButton_Click(object sender, EventArgs e)
    {
        if (dataGridView1.SelectedRows.Count != 1) { return; }
        
        string data = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        
        // show the form as a modal dialog box while editing.
        Form2 editForm = new Form2(data);
        
        if (editForm.ShowDialog() == DialogResult.OK)
        {
            // If the user clicks Save then we want to update the datagrid
            // (and eventually the database).
            dataGridView1.SelectedRows[0].Cells[1].Value = editForm.DataValue;
        }
    }
