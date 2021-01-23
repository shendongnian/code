        public MainWindow()
        {
            InitializeComponent();
            var contentControl = this as ContentControl;
            var control = this as Control;
            var frameworkElement = this as FrameworkElement;
            var uiElement = this as UIElement;
            var dependencyObject = this as DependencyObject;
            var dispatcher = this as DispatcherObject;
        }
