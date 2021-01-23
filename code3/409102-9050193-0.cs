    private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
            if (e.ColumnIndex == 0)
            {
                if (dataGridView2.IsCurrentCellDirty)
                    dataGridView2.CommitEdit(DataGridViewDataErrorContexts.Commit);
 
                if (dataGridView2.CurrentCell.Value.ToString().Equals("True"))
                {
                    MessageBox.Show("Now do the job while checked value changed to True.");
                    //
                    // Do the job here.
                    //
                }
            }
    }
