    private void lbz_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if( lbz.SelectedItem != null ){
            tb1.Text = File.ReadAllText(lbz.SelectedItem.ToString());
        } else {
            tb1.Text = "No File Selected";
        }
    }
