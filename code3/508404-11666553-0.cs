    string[] file = File.ReadAllLines(openFileDialog1.FileName, Encoding.Default);
    IEnumerable<string> groupQuery =
        from name in file
        let n = name.Split(';')
        group name by n[0] into g
        orderby g.Key
        select g;
    
    foreach (var g in groupQuery)
    {
        MessageBox.Show(g.Count() + " " +g.Key());
    }
