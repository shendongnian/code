        public static readonly DependencyProperty IsCheckedProperty =
            DependencyProperty.Register("IsChecked", typeof(bool),
            typeof(MyToggleSwitchControl), null);
 
        // .NET Property wrapper
        public bool IsChecked
        {
            get 
            { 
                return (bool)GetValue(IsCheckedProperty); 
            }
            set { SetValue(IsCheckedProperty, value); }
        }
