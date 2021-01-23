    private void bt_single_next_Click(object sender, System.Windows.RoutedEventArgs e) 
    {
        lock (GlobalV.Attached_Elements)
        {
            if (GlobalV.Attached_Elements.Count > 0) 
            {
                ...
            }
        }
    }
