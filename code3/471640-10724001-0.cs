        public MainWindow()
        {
            InitializeComponent();
            myEllipse.AddHandler(UIElement.MouseDownEvent, new RoutedEventHandler(OnMouseDown));
            myPanel.AddHandler(UIElement.MouseDownEvent, new RoutedEventHandler(OnMouseDown));
            myBorder.AddHandler(UIElement.MouseDownEvent, new RoutedEventHandler(OnMouseDown));
        }
        void OnMouseDown(object sender, RoutedEventArgs e)
        {
            UIElement uiElement = sender as UIElement;
            Debug.WriteLine(uiElement.GetType().ToString());
            e.Handled = true;
        }
