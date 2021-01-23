            public static readonly DependencyProperty ScrollViewVerticalOffsetProperty =
            DependencyProperty.Register(
                                        "ScrollViewVerticalOffset",
                                        typeof(double),
                                        typeof(MainPage),
                                        new PropertyMetadata(new PropertyChangedCallback(OnScrollViewVerticalOffsetChanged))
                                        );
            public static readonly DependencyProperty ScrollViewHorizontalOffsetProperty =
            DependencyProperty.Register(
                                        "ScrollViewHorizontalOffset",
                                        typeof(double),
                                        typeof(MainPage),
                                        new PropertyMetadata(new PropertyChangedCallback(OnScollViewHorizontalOffsetChanged))
                                        );
        private ScrollViewer _listScrollViewer;
        private void ScrollViewer_Loaded_1(object sender, RoutedEventArgs e)
        {
            _listScrollViewer = sender as ScrollViewer;
            Binding binding1 = new Binding();
            binding1.Source = _listScrollViewer;
            binding1.Path = new PropertyPath("VerticalOffset");
            binding1.Mode = BindingMode.OneWay;
            this.SetBinding(ScrollViewVerticalOffsetProperty, binding1);
            Binding binding2 = new Binding();
            binding2.Source = _listScrollViewer;
            binding2.Path = new PropertyPath("HorizontalOffset");
            binding2.Mode = BindingMode.OneWay;
            this.SetBinding(ScrollViewHorizontalOffsetProperty, binding2);
        }
        public double ScrollViewVerticalOffset
        {
            get { return (double)this.GetValue(ScrollViewVerticalOffsetProperty); }
            set { this.SetValue(ScrollViewVerticalOffsetProperty, value); }
        }
        public double ScrollViewHorizontalOffset
        {
            get { return (double)this.GetValue(ScrollViewHorizontalOffsetProperty); }
            set { this.SetValue(ScrollViewHorizontalOffsetProperty, value); }
        }
        private static void OnScrollViewVerticalOffsetChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            MainPage page = obj as MainPage;
            ScrollViewer viewer = page._listScrollViewer;
            // ... do something here
        }
        private static void OnScollViewHorizontalOffsetChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            MainPage page = obj as MainPage;
            ScrollViewer viewer = page._listScrollViewer;
            // ... do something here
        }
