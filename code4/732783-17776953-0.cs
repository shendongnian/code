    var selected = new List<string>();
    foreach (var arr in listboxName.SelectedItems)
    {
        selected.Add(arr.ToString());    
    }
    
    string finalStr = "some text before the values" + String.Join(", ", selected);
