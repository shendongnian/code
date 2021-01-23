    		private void NotchsList11_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
			Notch selectedItemData  = NotchsList11.SelectedItem as Notch;
            if (selectedItemData != null)
            {
				NavigationService.Navigate(new Uri(string.Format("/Test.xaml?parameter={0}",selectedItemData.articleid), UriKind.Relative));
            }
        }
