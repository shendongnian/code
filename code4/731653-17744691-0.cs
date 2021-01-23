    listBox.SelectionChanged += ShowMessageBox;
    
    private void ShowMessageBox(object sender, EventArgs e)
    {
       MessageBox.Show(listBox.SelectedItem.ToString());
    }
