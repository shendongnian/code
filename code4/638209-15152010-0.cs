    private void btnSort_Click(object sender, RoutedEventArgs e)
    {
        List<string> list = lstbxResults.Cast<string>().OrderBy(p=>p).ToList();
        
        lstbxResults.Clear();
        foreach(var item in list)
            lstbxResults.Items.Add(item);
    }
