        public double X
        {
            get { return (double)GetValue(XProperty); }
            set { SetValue(XProperty, value); }
        }
        public static readonly DependencyProperty XProperty =
            DependencyProperty.Register("X", typeof(double), typeof(MainPage), new PropertyMetadata(new PropertyChangedCallback(Callback)));
        public static void Callback(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            (o as MainPage).Xbox.Text = e.NewValue.ToString();
        }
        private void InsertCurrentBtnClick(object sender, RoutedEventArgs e)
        {
            X = 0.7;
        }
