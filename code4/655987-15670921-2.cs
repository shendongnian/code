    	    private void NotchsList11_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
				NavigationService.Navigate(new Uri(((Notch)e.AddedItems[0]).articleid, UriKind.Relative));
				((ListBox)sender).SelectedIndex = -1;
         
