            public static readonly DependencyProperty ListVerticalOffsetProperty =
            DependencyProperty.Register(
                                        "ListVerticalOffset",
                                        typeof(double),
                                        typeof(MyPage),
                                        new PropertyMetadata(new PropertyChangedCallback(OnListVerticalOffsetChanged))
                                        );
        private ScrollViewer _listScrollViewer;
        private void ScrollViewer_Loaded(object sender, RoutedEventArgs e)
        {
            _listScrollViewer = sender as ScrollViewer;
            Binding binding = new Binding();
            binding.Source = _listScrollViewer;
            binding.Path = new PropertyPath("VerticalOffset");
            binding.Mode = BindingMode.OneWay;
            this.SetBinding(ListVerticalOffsetProperty, binding);
        }
        public double ListVerticalOffset
        {
            get { return (double)this.GetValue(ListVerticalOffsetProperty); }
            set { this.SetValue(ListVerticalOffsetProperty, value); }
        }
        private double _lastFetch;
        private static void OnListVerticalOffsetChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            MyPage page = obj as MyPage;
            ScrollViewer viewer = page._listScrollViewer;
            if (viewer != null)
            {
                if (page._lastFetch < viewer.ScrollableHeight)
                {
                    // Trigger within 1/4 the viewport.
                    if (viewer.VerticalOffset >= (viewer.ScrollableHeight - (viewer.ViewportHeight / 4)))
                    {
                        page._lastFetch = viewer.ScrollableHeight;
                        MyViewModel _tmpviewmodel = page.DataContext as MyViewModel;
                        if ((_tmpviewmodel != null) && (_tmpviewmodel.HasMoreItems))
                            _tmpviewmodel.GetMoreItems();
                    }
                }
            }
        }
