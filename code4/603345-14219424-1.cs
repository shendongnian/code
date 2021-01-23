    for(int i = 0; i < ListBox1.Items.Count; i++)
    {
        ListItem item = ListBox1.Items[i];
        WebService1 ws = new WebService1();
        int flag = ws.callFlags(10, item.Text);
        if (flag == 1)
        {
            ListBox1.Items.Remove(item); // <- You'll have an issue with the remove
        }
    }
