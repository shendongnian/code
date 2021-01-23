    private void cbTest1_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        var q = from i in cbTest1.ItemsSource.Cast<ComboBoxItem>()
                where ((string)i.Content).StartsWith(e.Text, StringComparison.OrdinalIgnoreCase)
                select i;
        if (q.Count() == 1)
        {
            // Have typed out a unique name match.
            var ActiveItem = cbTest1.SelectedItem;
        }
        else
        {
            // Name does not match or has multiple matches.
        }
    }
    private void cbTest1_DropDownClosed(object sender, EventArgs e)
    {
        var ActiveItem = cbTest1.SelectedItem;
    }
