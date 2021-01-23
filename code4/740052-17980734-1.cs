        public static readonly DependencyProperty ReloadProperty = DependencyProperty.Register("Reload", typeof (bool), typeof (BorderEx), new PropertyMetadata(default(bool), ReloadClicked));
        public bool Reload
        {
            get { return (bool) GetValue(ReloadProperty); }
            set { SetValue(ReloadProperty, value); }
        }
