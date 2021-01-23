    var item = emails.SelectedItem;
    if (item != null)//may be !string.IsNullOrEmpty
    {
        for (int i = 1; i < item.Count; i++)//may be item.Lenght
        {
             clone.Items.Add(item.Insert(i, "."));
        }
    }
