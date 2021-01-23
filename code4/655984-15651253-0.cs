        private void NotchsList11_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (NotchsList11.SelectedItem != null)
            {
                NavigationService.Navigate(new Uri(string.Format("/Test.xaml?parameter={0}",
                    (NotchsList11.SelectedItem as Notch).articleid), UriKind.Relative));
            }
        } 
