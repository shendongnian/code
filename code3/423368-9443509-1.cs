    private void Paste()
    {
        foreach (ListViewItem item in copiedItems)
        {
            fmc.PasteFromCopy(item.Text, somePath);
        }
    }
