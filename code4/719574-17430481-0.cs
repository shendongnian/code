        public PointItem CurrentPointItem
        {
            get { return (PointItem)GetValue(CurrentPointItemProperty); }
            set { SetValue(CurrentPointItemProperty, value); }
        }
        // Using a DependencyProperty as the backing store for CurrentPointItem.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentPointItemProperty =
            DependencyProperty.Register("CurrentPointItem", typeof(PointItem), typeof(MainWindow), new PropertyMetadata(null));
