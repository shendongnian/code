    private void lls_SelectionChanged(object sender, SelectionChangedEventArgs e) {
      var spList = new List<StackPanel>();
      GetItemsRecursive<StackPanel>(lls, ref spList);
      // Selected. 
      if (e.AddedItems.Count > 0 && e.AddedItems[0] != null) {
        foreach (var sp in spList) {
          if (e.AddedItems[0].Equals(sp.DataContext)) {
            sp.Background = new SolidColorBrush(Colors.Green);
            sp.Children.Add(new TextBlock { Text = "Hello" });
          }
        }
      }
      // Unselected. 
      if (e.RemovedItems.Count > 0 && e.RemovedItems[0] != null) {
        foreach (var sp in spList) {
          if (e.RemovedItems[0].Equals(sp.DataContext)) {
            sp.Background = (SolidColorBrush)Resources["PhoneBackgroundBrush"];
            sp.Children.RemoveAt(sp.Children.Count - 1);
          }
        }
      } 
    }
