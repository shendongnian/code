    void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
        bool valueFromSettings = false;
        
        if (!localSettings.Values.ContainsKey("isFirstChecked"))
        {
            // if the setting doesn't exist, probably wise to create it here.
            // setting the default to "false", but you can change to true if that makes more sense.
            localSettings.Values.Add("isFirstChecked", false);
        }
        else
        {
            // read the value of the setting here.  
            // If we just created it, it should default to false (see above)
            valueFromSetting = ((bool)localSettings.Values["isFirstChecked"]);
        }
         
        if(valueFromSettings)
        {
            cbFirst.IsChecked = true;
            test.Text = "Checked";
        }
        else 
        {
            cbFirst.IsChecked = false;
            test.Text = "UnChecked";
        }
    }
