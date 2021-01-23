    private void DataGridView1_UserDeletingRow(object sender, System.Windows.Forms.DataGridViewRowCancelEventArgs e)
    {
       DialogResult response = MessageBox.Show("Are you sure you want to delete this row?", "Delete row?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
       if ((response == DialogResult.No))
       {
          e.Cancel = true;
       }
    }
