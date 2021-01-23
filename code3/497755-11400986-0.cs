    private void lbz_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if( lbz.SelectedItem != null ){
            if(File.Exist(lbz.SelectedItem.ToString())){
                tb1.Text = File.ReadAllText(lbz.SelectedItem.ToString());
            }
            else
            {
                tb1.Text = "File is not exist in the selected Path";
            }
        } else {
            tb1.Text = "No File Selected";
        }
    }
