    private void AddListBoxItem(string item)
    {
        if(!InvokeRequired)
        {
            listBox2.Items.Add(item);
        }
        else
        {
            var callback = new Action<string>(AddListBoxItem);
            Invoke(callback, new object[]{item});
        }
    }
