    private void btn_Delete_Click(object sender, EventArgs e) 
    {       
        if (rdb_Delete.Checked)
        {
            foreach (DataGridViewRow row in DataGridView1.SelectedRows)
            {
                //delete record and then remove from grid. 
                // you can use your own query but not necessary to use rowid
                int selectedIndex = row.Index;         
                
                // gets the RowID from the first column in the grid
                int rowID = int.Parse(DataGridView1[0, selectedIndex].Value.ToString());
                string sql = "DELETE FROM Table1 WHERE RowID = @RowID";
               
                // your code for deleting it from the database
                // then your code for refreshing the DataGridView
  
                DataGridView1.Rows.Remove(row);
            }
        }
    }
