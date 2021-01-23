    private void dgTasks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var button = (DataGridView)sender;
            if (button.Columns[6] is DataGridViewColumn && e.RowIndex >= 0)
            {
           MessageBox.Show("You have clicked Cancel button of a row of datagridview ", "Task", MessageBoxButtons.OK, MessageBoxIcon.Information); 
            }
            }
