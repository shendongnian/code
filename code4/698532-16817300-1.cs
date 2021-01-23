    private void CheckBox_Checked(object sender, RoutedEventArgs e)
    {
         //Get the boolean current value [true or false]
         bool valueSelectedToBool = (sender as CheckBox).IsChecked;
    
         //Get the string current value ["true" or "false"]
         string valueSelectedToString = (sender as CheckBox).IsChecked.ToString();
    
         MessageBox.Show(valueSelectedToString );
    } 
