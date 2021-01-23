    public static readonly DependencyProperty itemsSourceProperty = ItemsControl.ItemsSourceProperty.AddOwner(
                                                                            typeof(MyCustomControl), 
                                                                            new FrameworkPropertyMetadata(
                                                                                ItemsSourcePropertyChangedCallback));
        public System.Collections.IEnumerable ItemsSource
        {
            get
            { return (System.Collections.IEnumerable)GetValue(itemsSourceProperty); }
            set
            { SetValue(itemsSourceProperty, value); }
        }
        private static void ItemsSourcePropertyChangedCallback(DependencyObject controlInstance, DependencyPropertyChangedEventArgs args)
        {
            MyCustomControlraceUIGridControlInstance = (MyCustomControl)controlInstance;  
            raceUIGridControlInstance.extendedDataGrid.ItemsSource = (System.Collections.IEnumerable)args.NewValue;            
        }
