        private void uncheckCheckBoxes(object sender)
        {
            if (radioButtonEdit.IsChecked == true)
            {
                CheckBox currentcheckbox = (CheckBox)sender;
    
                foreach (var checkBox in ManyCheckBoxes.Children.OfType<CheckBox>().Where(cb => (bool)cb.IsChecked))
                {
                    if (!currentcheckbox.Name.Equals(checkBox.Name))
                    {
                        checkBox.IsChecked = false;
                    }
                }
             }
        }
        private void checkbox1_Checked(object sender, RoutedEventArgs e)
        {
            uncheckCheckBoxes(sender);
        }
    
