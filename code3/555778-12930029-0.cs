    private DateTime _lastKeyPress;
    private string _searchString;
    private void ListBox1KeyPress(object sender, KeyPressEventArgs e)
    {
        var newDate = DateTime.Now;
        var diff = newDate - _lastKeyPress;
    
        if (diff.TotalSeconds >= 1.5)
            _searchString = string.Empty;
        _searchString += e.KeyChar;
        
        for (var i = 0; i < listBox1.Items.Count; i++)
        {
            var item = listBox1.Items[i].ToString();
            if (item.ToLower().StartsWith(_searchString))
            {
                listBox1.SelectedItem = item;
                break;
            }
        }
        _lastKeyPress = newDate;
        e.Handled = true; //REALLY IMPORTANT TO HAVE THIS
    }
