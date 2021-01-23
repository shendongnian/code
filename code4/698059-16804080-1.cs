    // if there aren't any selected items
    if (listView1.SelectedItems.Count <= 0)
    {
       // then give an error
       MessageBox.Show("Please Select Value First", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
       return;
    }
    // otherwise proceed
