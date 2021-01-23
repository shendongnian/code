        public bool IsToggleChecked
        {
            get { return (bool)GetValue(IsToggleCheckedProperty); }
            set { SetValue(IsToggleCheckedProperty, value); }
        }
        public static readonly DependencyProperty IsToggleCheckedProperty =
            DependencyProperty.Register("IsToggleChecked", typeof(bool), typeof(MyToggleSwitchControl), new PropertyMetadata(false));
