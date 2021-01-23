    public static class DataGridAttachedProperty
    {
         public static DataGrid _storedDataGrid;
         public static Boolean GetResortOnCollectionChanged(DataGrid dataGrid)
         {
             return (Boolean)dataGrid.GetValue(ResortOnCollectionChangedProperty);
         }
         public static void SetResortOnCollectionChanged(DataGrid dataGrid, Boolean value)
         {
             dataGrid.SetValue(ResortOnCollectionChangedProperty, value);
         }
        /// <summary>
        /// Exposes attached behavior that will trigger resort
        /// </summary>
        public static readonly DependencyProperty ResortOnCollectionChangedProperty = 
             DependencyProperty.RegisterAttached(
            "ResortOnCollectionChangedProperty", typeof (Boolean),
             typeof(DataGridAttachedProperty),
             new UIPropertyMetadata(false, OnResortOnCollectionChangedChange));
        private static void OnResortOnCollectionChangedChange
            (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
          _storedDataGrid = dependencyObject as DataGrid;
          if (_storedDataGrid == null)
            return;
    
          if (e.NewValue is Boolean == false)
            return;
    
          var observableCollection = _storedDataGrid.ItemsSource as ObservableCollection;
          if(observableCollection == null)
            return;
          if ((Boolean)e.NewValue)
            observableCollection.CollectionChanged += OnCollectionChanged;
          else
            observableCollection.CollectionChanged -= OnCollectionChanged;
        }
    
        private static void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
          if (e.OldItems == e.NewItems)
            return;
    
          _storedDataGrid.Items.Refresh()
        }
    }
