        var colorProperties = Colors.GetType().GetProperties(BindingFlags.Static | BindingFlags.Public);
        var colors = colorProperties.Select(prop => (Color)prop.GetValue(null, null));
        foreach(Color c in colors)
        {
            ListBoxItem l = new ListBoxItem();
            l.Content = c.ToString();
            l.Color = c;
            listbox1.Items.Add(l);
        }
