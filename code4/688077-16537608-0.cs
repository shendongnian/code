    private void listViewUserList_MouseUp(object sender, MouseEventArgs e)
    {
        if (listViewUserList.SelectedItems.Count > 0)
        {
            selectedRowIndex = listViewUserList.SelectedItems[0].Index;
        }
        else
        {
            listViewUserList.Items[selectedRowIndex].Selected = true;
        }
    }
