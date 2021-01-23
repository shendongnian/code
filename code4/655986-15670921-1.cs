    private void NotchsList11_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
			Notch selectedItemData  = NotchsList11.SelectedItem as Notch;
            if (selectedItemData != null)
            {
				NavigationService.Navigate(new Uri("/Test.xaml", UriKind.Relative));
				FrameworkElement root = Application.Current.RootVisual as FrameworkElement;
                root.DataContext = selectedItemData;
            }
        }
