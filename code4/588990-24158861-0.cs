      private void itemGridView_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
      {
       GridView oGridView = sender as GridView;
       if (oGridView != null && args.NewValue != null)
       {
        ObservableCollection<yourclass> yourCol = args.NewValue as ObservableCollection<yourclass>;
        for(int i= 0; i<yourCol.Count; i++)
         // do your checking...
         if (YourChecking) oGridView.SelectedIndex = i;
       } 
      }
