    private void DataGridResults_CopyingRowClipboardContent(object sender, DataGridRowClipboardEventArgs e)
    {
        int y = 0;
       
        for (int i = 0; i < e.EndColumnDisplayIndex; i++)
        {
            if (i != DataGridResults.CurrentCell.Column.DisplayIndex)
            {
                e.ClipboardRowContent.RemoveAt(i - y);
                y++;
            }
        }
    }
