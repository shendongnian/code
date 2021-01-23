        #region MyProperty (DependencyProperty)
        public int MyProperty
        {
            get { return (int)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }
        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.Register("MyProperty", typeof(int), typeof(MainWindow),
              new PropertyMetadata(0, ChangedCallback));
        private static void ChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Console.WriteLine("Dependency property is now " + e.NewValue);
        }
        #endregion
