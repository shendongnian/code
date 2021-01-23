    private void addItem(string item)
    {
        if (this.pathListBox.InvokeRequired)
        {
            this.Invoke(new Action<string>(addItem), item);
        }
        else 
        {
            this.pathListBox.Items.Add(item);
        }
    }
