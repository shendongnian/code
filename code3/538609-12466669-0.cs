    private void myButton_Click(object sender, EventArgs e)
    {
        foreach (DataGridViewRow row in usersGrid.Rows)
        {
            if (this.usersGrid.SelectedRows.Count == 1)
            {
             // get information of 1st column from the row
             string selectedUser = this.usersGrid.SelectedRows[0].Cells[0].ToString();
            }
        }
    }
