    int i = 1;
    while (rdr.Read()) {
        Button btn =   FindChild<Button>(this, "Item" + i);
        TextBlock tb = FindChild<TextBlock>(btn, "Item" + i  + "txt");
        btn.Visibility = Visibility.Visible;
        tb.Text = rdr.GetString("item_name");
        i++;
    }
