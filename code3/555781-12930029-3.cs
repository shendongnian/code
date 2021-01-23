    private void ListBox1KeyPress(object sender, KeyPressEventArgs e)
    {
        var newDate = DateTime.Now;
        var diff = newDate - _lastKeyPress;
        if (diff.TotalSeconds >= 1.5)
            _searchString = string.Empty;
        _searchString += e.KeyChar;
        var found = listBox1.Items.Cast<object>().Select(t => t.ToString()).Where(item => item.ToLower().StartsWith(_searchString)).FirstOrDefault();
        if(!String.IsNullOrEmpty(found))
            listBox1.SelectedItem = found;
            
        _lastKeyPress = newDate;
        e.Handled = true;
    }
