    private void checkBox_KeyDown(object sender, KeyEventArgs e)
    {
        var checkbox = sender as CheckBox;
        if (checkbox == checkbox1 && e.KeyCode == Keys.NumPad1)
        {
            checkbox.IsChecked = !checkbox.IsChecked;
            return;
        }
        if (checkbox == checkbox2 && e.KeyCode == Keys.NumPad2)
        {
            checkbox.IsChecked = !checkbox.IsChecked;
            return;
        }
        // And so on...
    }
