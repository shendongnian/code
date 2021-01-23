    private void checkBox_KeyDown(object sender, KeyEventArgs e)
    {
        var checkbox = sender as CheckBox;
        if (checkbox == null) { return; }
        if (e.KeyCode == Keys.NumPad1)
        {
            _checkbox1.IsChecked = !_checkbox1.IsChecked;
            return;
        }
        if (e.KeyCode == Keys.NumPad2)
        {
            _checkbox2.IsChecked = !_checkbox2.IsChecked;
            return;
        }
        // And so on...
    }
