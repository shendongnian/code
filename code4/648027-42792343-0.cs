    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        //it checks if the row index of the cell is greater than or equal to zero
        if (e.RowIndex >= 0)
        {
            //gets a collection that contains all the rows
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            //populate the textbox from specific value of the coordinates of column and row.
            txtid.Text = row.Cells[0].Value.ToString();
            txtname.Text = row.Cells[1].Value.ToString();
            txtsurname.Text = row.Cells[2].Value.ToString();
            txtcity.Text = row.Cells[3].Value.ToString();
            txtmobile.Text = row.Cells[4].Value.ToString();
        }
 
    }
