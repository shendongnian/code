     private void button3_Click(object sender, EventArgs e)
     {
        if (MessageBox.Show("Do you want to delete this row ?", "Delete",     MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
            dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
           string sql="write your Delete query"
          OleDbCommand dCommand = new OleDbCommand(sql, connection);
            OleDbCommandBuilder builder = new OleDbCommandBuilder(sAdapter);
           sAdapter.DeleteCommand=dCommand
            sAdapter.Update(sTable);
        }
    }
    //Save...
    private void button4_Click(object sender, EventArgs e)
    {
         string sql="write your update query"
         OleDbCommand uCommand = new OleDbCommand(sql, connection);
         OleDbCommandBuilder builder = new OleDbCommandBuilder(sAdapter);
         sAdapter.UpdateCommand=uCommand 
        sAdapter.Update(sTable);
        dataGridView1.ReadOnly = true;
        button4.Enabled = false;
        button2.Enabled = true;
        button3.Enabled = true;
    }
