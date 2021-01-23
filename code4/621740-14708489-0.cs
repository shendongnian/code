    private void yourListView_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (yourListView.SelectedItems.Count == 0)
            return;    
       
        ListViewItem item = yourListView.SelectedItems[0];
        //fill the text boxes
        textBoxID.Text = item.Text;
        textBoxName.Text = item.SubItems[0].Text;
        textBoxPhone.Text = item.SubItems[1].Text;
        textBoxLevel.Text = item.SubItems[2].Text;
    }
