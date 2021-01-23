            Run target;
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < 1000; i++)
            {
                var run = new Run("Inline number " + i.ToString() + ". ");
                if (i==850)
                    target = run;
                textBlock1.Inlines.Add(run);
            }
        }
        public void findButton_Click_1(object sender, RoutedEventArgs e)
        {
            var contentStart = target.ContentStart;
            var rect = contentStart.GetCharacterRect(LogicalDirection.Forward);
            scrollViewer1.ScrollToVerticalOffset(rect.Top);
        }
