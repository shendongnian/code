    var check = comboBox1.Items.Cast<string>()
                         .ToList()
                         .FirstOrDefault(c => c.Contains(ListBox.SelectedItem));
    if (check != null)
    {
       //do stuff
       found = true;
    }
    else
    {
       //do stuff
       found = false;
    }
