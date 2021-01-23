    private void listPicker1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListPickerItem lpi = (sender as ListPicker).SelectedItem as ListPickerItem;
            var text = urTextBox.Text;        
            urTextBox.Text = lpi.Content + "_" + text; 
        }
    
        private void OtherTextBoxChanged(object sender, TextChangedEventArgs e)
        {
            var Othertext = (sender as TextBox).Text
            var text = urTextBox.Text;        
            urTextBox.Text = text + "_" + Othertext; 
        }
