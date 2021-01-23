     string selectedPort = string.Empty;
     private void Menu_Port_Click(object sender, RoutedEventArgs e)
     {
         MenuItem selectedMenu = ((MenuItem)sender);
         Menu_Port.Items.Cast<MenuItem>().Where(
           menu => menu != selectedMenu).ToList().ForEach(item => item.IsChecked = false);
         if (selectedMenu.IsChecked)
         {
            selectedPort = selectedMenu.Header.ToString();
         }
         else
         {
            selectedPort = string.Empty;
         }
     }
