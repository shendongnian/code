    for (int i = listView1.Items.Count - 1; i >= 0; i--)
    {
        if (listView1.Items[i].Selected)
        {
            listView1.Items[i].Remove();
        }
    }
