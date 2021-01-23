    public class MyControl : Control
    {
        public ObservableCollection<string> ExtraColumns
        {
            get { return (ObservableCollection<string>)GetValue(ExtraColumnsProperty); }
            set { SetValue(ExtraColumnsProperty, value); }
        }
        public static readonly DependencyProperty ExtraColumnsProperty =
            DependencyProperty.Register("ExtraColumns", typeof(ObservableCollection<string>), typeof(MyControl),
                                        new PropertyMetadata(new ObservableCollection<string>(), OnChanged));
        static void OnChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            (sender as MyControl).OnChanged();
            
        }
        void OnChanged()
        {
            if ( ExtraColumns != null )
                ExtraColumns.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(ExtraColumns_CollectionChanged);
        }
        void ExtraColumns_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("Changed");    
        }
    }
