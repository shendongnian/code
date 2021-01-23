    if (emails.SelectedItem != null)
    {
        var item = emails.SelectedItem.ToString();
        for (int i = 1; i < item.Length; i++)
        {
             clone.Items.Add(item.Insert(i, "."));
        }
    }
