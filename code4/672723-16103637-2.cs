    protected void btnallsd_Click(object sender, EventArgs e)
    {
        var selected = lstsource.Items.Cast<ListItem>()
                       .Where(li => li.Selected);
        while (selected.Any())
        {
            var item = selected.First();
            lstdestination.Items.Add(item);
            lstsource.Items.Remove(item);
        }
        lstdestination.ClearSelection();
    }
