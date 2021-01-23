    private void myListView_AfterLabelEdit(object sender, LabelEditEventArgs e)
    {
        MessageBox.Show("You Renamed Me to: " + e.Label.ToString());
    
        if (deviceDictionary.ContainsKey(myListView.Items[e.Item].Name))
        {
            MessageBox.Show("Entry updated");
        }
    }
