    foreach (ListItem  item in ListBox1.Items)
     {
      if (item.Selected)
      {
        selectedItem.Add(item.Text); // selectedImte.Add(item.Value);
      }
    }
