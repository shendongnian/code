    private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selVal = (int)comboBox1.SelectedValue;
            if ((selVal % 2) == 0)
            {
                // remove the style
                textBox2.Style = null;
                // remove from the button's IsEnabled multibinding                 
                _vfs.NumberValidationFlag = false;
                BindingOperations.ClearBinding(button1, Button.IsEnabledProperty);
                BindingOperations.SetBinding(button1, Button.IsEnabledProperty, GetBindingForButton());                
            }
            else
            {
                // add back the style
                Style myStyle = (Style)Application.Current.Resources["requiredFieldValidationStyle"];
                textBox2.Style = myStyle;
                // add back to the button's IsEnabled multibinding                
                _vfs.NumberValidationFlag = true;
                BindingOperations.ClearBinding(button1, Button.IsEnabledProperty);
                BindingOperations.SetBinding(button1, Button.IsEnabledProperty, GetBindingForButton());
            }
        }
