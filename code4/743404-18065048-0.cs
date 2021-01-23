    if (listBox1.SelectedItem is DataRowView)
    {
        DataRowView drv = (DataRowView)listBox1.SelectedItem;
        String s = drv["RoomID"] as String;
        if (!String.IsNullOrEmpty(s))
            MessageBox.Show(s);
    }
