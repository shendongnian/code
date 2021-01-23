    string[] file = File.ReadAllLines(openFileDialog1.FileName, Encoding.Default);
    IEnumerable<string> groupQuery =
        from name in file
        group name by name into g
        orderby g.Key
        select g;
    
    foreach (var g in groupQuery)
    {
        MessageBox.Show(g.Count() + " " + g.Key);
    }
