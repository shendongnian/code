    List<string> categories = new List<sting>();
    categories.Add("Cat 1");
    categories.Add("Cat 2");
    categories.Add("Cat 3");
    for (int i = 0; i < clBCategory.Items.Count; i++)
    {
        if (categories.Contains(clBCategory.Items[i].ToString()))
            clBCategory.SetItemChecked(i, true);
    } 
