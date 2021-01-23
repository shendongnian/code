     private void button3_Click(object sender, EventArgs e)
     {
        if (MessageBox.Show("Do you want to delete this row ?", "Delete",     MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
            dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
            OleDbCommandBuilder builder = new OleDbCommandBuilder(sAdapter);
            sAdapter.Update(sTable);
        }
    }
    //Save...
    private void button4_Click(object sender, EventArgs e)
    {
         OleDbCommandBuilder builder = new OleDbCommandBuilder(sAdapter);
        sAdapter.Update(sTable);
        dataGridView1.ReadOnly = true;
        button4.Enabled = false;
        button2.Enabled = true;
        button3.Enabled = true;
    }
