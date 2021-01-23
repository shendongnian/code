    private void btnCopy_Click(object sender, EventArgs e)
        {
            copiedItems = listView1..SelectedItems.Cast<ListViewItem>().Select(li => li.ToolTipText).ToList();
            infoLabel.Text = "Item(s) copied to clipboard.";
        }
