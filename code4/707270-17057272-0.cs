    // In Constructor:
    cbHours.Items.Add(new DateTime(2000, 1, 1, 8, 0, 0));
    cbHours.Items.Add(new DateTime(2000, 1, 1, 10, 0, 0));
    cbHours.Items.Add(new DateTime(2000, 1, 1, 13, 0, 0));
    cbHours.FormatString = "h tt";
    // In event handler
    if (cbHours.SelectedIndex >= 0)
    {
        int hour = ((DateTime)cbHours.SelectedItem).Hour
        // do things with the hour
    }
