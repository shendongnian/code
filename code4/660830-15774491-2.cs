    memlist.ClearSelected(); // clear previous selection
    memlist.Items.Cast<object>()
           .Select((item, index) => new { Text = memlist.GetItemText(item), Index = index })
           .Where(x => x.Text.StartsWith(term, StringComparison.CurrentCultureIgnoreCase))
           .ToList()
           .ForEach(x => memlist.SetSelected(x.Index, true));
