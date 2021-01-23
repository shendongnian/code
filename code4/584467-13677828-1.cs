         public MainWindow()
        {
            InitializeComponent();
            textBlock1.Inlines.Add(new Run("One "));
            textBlock1.Inlines.Add(new Run("Two "));
            textBlock1.Inlines.Add(new Run("Three "));
        }
        private SolidColorBrush _blackBrush = new SolidColorBrush(Colors.Black);
        private SolidColorBrush _redBrush = new SolidColorBrush(Colors.Red);
        private Run _selectedRun;
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var run = e.OriginalSource as Run;
            if (run != null)
            {
                if (_selectedRun != null)
                {
                    _selectedRun.Foreground = _blackBrush;
                    if (_selectedRun == run)
                    {
                        return;
                    }
                }
                run.Foreground = _redBrush;
                _selectedRun = run;
            }
        }
