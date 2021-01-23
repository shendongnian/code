    int i = 1;
    while (rdr.Read()) {
        Control label = this.Controls["Item" + i];
        Control button =  this.Controls["Item" + i + "txt"];
        label.Visibility = Visibility.Visible;
        button.Text = rdr.GetString("item_name");
        i++;
    }
