     List<ListItem> list = new List<ListItem>(ListBox7.Items.Cast<ListItem>());
      list = list.OrderBy(li => int.Parse(li.Text.TrimStart('B')))
                 .ToList<ListItem>();
      ListBox7.Items.Clear();
      ListBox7.Items.AddRange(list.ToArray<ListItem>()); 
