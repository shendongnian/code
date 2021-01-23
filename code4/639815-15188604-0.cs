    if (listTime.SelectedIndex != -1)
    {
        var item = listTime.SelectedItem as Duration;
        MessageBox.Show(item.Value.ToString());
    }
