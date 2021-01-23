    void startTransferFiles()
    {
        foreach (ListViewItem item in listView1.Items)
        {
            if ((bool)item.Tag == false)
            {
                Send(item.ToolTipText);
                item.Tag = true;
            }
        }
    }
