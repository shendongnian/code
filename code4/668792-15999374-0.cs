        public bool IsFlying
        {
            get { return (bool)GetValue(IsFlyingProperty); }
            set { SetValue(IsFlyingProperty, value); }
        }
        public static readonly DependencyProperty IsFlyingProperty =
            DependencyProperty.Register("IsFlying", typeof(bool), 
               typeof(SampleUserControl), new UIPropertyMetadata(true));
