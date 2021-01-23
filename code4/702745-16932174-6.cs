    private void Menu_Port_Click(object sender, RoutedEventArgs e)
    {
       string selectedPort = ((MenuItem)sender).Header.ToString();
       // Alternatively, if you want to maintain a list of selected ports, you can do something like this:
       MenuItem selectedMenu = ((MenuItem)sender);
       if (selectedMenu.IsChecked)
       {
          // In this case "allSelectedPorts" is a global string list.
          allSelectedPorts.Add(selectedMenu.Header.ToString());
       }
       else
       {
          allSelectedPorts.Remove(selectedMenu.Header.ToString());
       }
    }
