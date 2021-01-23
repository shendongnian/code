     public MainWindow()
            {
                InitializeComponent();
            }
            #region MainContentDp (DependencyProperty)
            public object MainContentDp
            {
                get { return GetValue(MainContentDpProperty); }
                set { SetValue(MainContentDpProperty, value); }
            }
            public static readonly DependencyProperty MainContentDpProperty =
                DependencyProperty.Register("MainContentDp", typeof(object), typeof(MainWindow),
                  new PropertyMetadata(OnMainContentDpChanged));
            private static void OnMainContentDpChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                MainWindow mainWindow = d as MainWindow;
                if (mainWindow != null)
                {
                    mainWindow.MainContentRegion.DataContext = e.NewValue;
                }
            }
            #endregion
            #region StatusBarDp (DependencyProperty)
            public object StatusBarDp
            {
                get { return GetValue(StatusBarDpProperty); }
                set { SetValue(StatusBarDpProperty, value); }
            }
            public static readonly DependencyProperty StatusBarDpProperty =
                DependencyProperty.Register("StatusBarDp", typeof(object), typeof(MainWindow),
                  new PropertyMetadata(OnStatusBarDpChanged));
            private static void OnStatusBarDpChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                MainWindow mainWindow = d as MainWindow;
                if (mainWindow != null)
                {
                    mainWindow.StatusBarRegion.DataContext = e.NewValue;
                }
            }
            #endregion
