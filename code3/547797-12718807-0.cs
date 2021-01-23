        foreach (Color c in System.Drawing.Color)
        {
            ListBoxItem l = new ListBoxItem();
            l.Content = C.ToString();
            l.Color = c;
            listbox1.Items.Add(c);
        }
