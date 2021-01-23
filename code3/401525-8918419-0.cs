    public class EnhancedBusyIndicator : BusyIndicator
    {
        public EnhancedBusyIndicator()
        {
            Loaded += new RoutedEventHandler(EnhancedBusyIndicator_Loaded);
        }
        void EnhancedBusyIndicator_Loaded(object sender, RoutedEventArgs e)
        {
            AllowedToFocus = true;
        }
        private readonly DependencyProperty AllowedToFocusProperty = DependencyProperty.Register("AllowedToFocus", typeof(bool), typeof(EnhancedBusyIndicator), new PropertyMetadata(true));
        public bool AllowedToFocus
        {
            get { return (bool)GetValue(AllowedToFocusProperty); }
            set { SetValue(AllowedToFocusProperty, value); }
        }
        public readonly DependencyProperty ControlToFocusOnProperty = DependencyProperty.Register("ControlToFocusOn", typeof(Control), typeof(EnhancedBusyIndicator), null);
        public Control ControlToFocusOn
        {
            get { return (Control)GetValue(ControlToFocusOnProperty); }
            set { SetValue(ControlToFocusOnProperty, value); }
        }
        protected override void OnIsBusyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnIsBusyChanged(e);
            if (AllowedToFocus && !IsBusy)
            {
                Dispatcher.BeginInvoke(() => { ControlToFocusOn.Focus(); });
                AllowedToFocus = false;
            }
        }
    }
