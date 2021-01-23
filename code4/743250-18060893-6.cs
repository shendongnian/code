        public static readonly DependencyProperty SelectedText2Property = DependencyProperty.RegisterAttached("SelectedText2",
            typeof(string), typeof(SmartTextBox), new PropertyMetadata(""));
        public string SelectedText2
        {
            get { return (string)GetValue(SelectedText2Property); }
            set { SetValue(SelectedText2Property, value); }
        }
        protected override void OnLostFocus(RoutedEventArgs e)
        {
            SelectedText2 = this.SelectedText;
            base.OnLostFocus(e);
        }
