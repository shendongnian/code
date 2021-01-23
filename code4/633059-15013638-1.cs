    foreach (ListItem li in sp_list.Items)
    {
        for (int i = current.Count - 1; i >= 0; i--)
        {
            if (li.Text == current[i].uname)
            {
                current.RemoveAt(i);
            }
        }
    }
