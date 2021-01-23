    private void checkbox1_Checked(object sender, RoutedEventArgs e)
        {
            if (radioButtonEdit.IsChecked == true)
            {
                CheckBox currentbox = (CheckBox)sender;
                foreach (var checkbox in ManyCheckBoxes.Children.OfType<CheckBox>().Where(cb => (bool)cb.IsChecked))
                {
                    if (!currentbox.Name.Equals(checkBox.Name))
                    {
                        checkBox.IsChecked = false;
                    }
                }
            }
        }
