    private void addItem(string item)
    {
        if (this.InvokeRequired)
        {
            this.BeginInvoke(new Action<string>(addItem), item);
            return;
        }
        this.pathListBox.Items.Add(item);
    }
