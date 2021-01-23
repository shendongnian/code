        private void cmbValue1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selection = (sender as ComboBox).SelectedItem as ComboBoxItem;
            //If the tag is a TableContainer, then the user has selected a sub-query.
            if (selection != null && selection.Tag != null && selection.Tag.GetType() == typeof(TableContainer))
            { 
                //This is the only way to disable an event action
                (sender as ComboBox).TextChanged -= sender_OnTextChanged; 
                (sender as ComboBox).Text = "[Selected Table]";
                (sender as ComboBox).TextChanged += sender_OnTextChanged; 
                //But as said above though, you could also do this:
                (sender as ComboBox).SelectedText = "[Selected Table]";
            }
        }
