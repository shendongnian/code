    private void statesListBox_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        //Select a state to remove from list box
        if (statesListBox.SelectedItem != null)
            return;
        if (statesListBox.SelectedItem.ToString().Length != 0)
        {            
            if (
                MessageBox.Show("Are you sure you want to delete " + 
                                statesListBox.SelectedItem.ToString() + "?", "Delete" 
                                + statesListBox.SelectedItem.ToString(), 
                                MessageBoxButtons.YesNo, MessageBoxIcon.Information) 
                == DialogResult.Yes
           )
            statesListBox.Items.Remove(statesListBox.SelectedItem);
        }
    }
