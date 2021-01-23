     string PathFecha = 
        System.IO.Path.Combine(
         ConfigurationManager.AppSettings.ToString(),
         Drp_List1.SelectedItem.Text,
         Drp_List2.SelectedItem.Text,
         Drp_List3.SelectedItem.Text);
