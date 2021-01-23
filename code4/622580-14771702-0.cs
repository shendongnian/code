        public ErrorProvider()
        {
            this.DataContextChanged += new DependencyPropertyChangedEventHandler(ErrorProvider_DataContextChanged);
            this.Loaded += new RoutedEventHandler(ErrorProvider_Loaded);
        }
