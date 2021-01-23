    [TemplateVisualState(GroupName = "WaitGroup", Name = WaitSpinner.IsWaitingStateName)]
    [TemplateVisualState(GroupName = "WaitGroup", Name = WaitSpinner.NotWaitingStateName)]
    public class WaitSpinner : ContentControl
    {
        #region States names
        internal const String IsWaitingStateName = "IsWaitingState";
        internal const String NotWaitingStateName = "NotWaitingState";
        #endregion States names
        public bool IsWaiting
        {
            get { return (bool)GetValue(IsWaitingProperty); }
            set { SetValue(IsWaitingProperty, value); }
        }
        public static readonly DependencyProperty IsWaitingProperty =
            DependencyProperty.Register("IsWaiting", typeof(bool), typeof(WaitSpinner), new PropertyMetadata(false, OnIsWaitingPropertyChanged));
        private static void OnIsWaitingPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            WaitSpinner waitSpinner = (WaitSpinner)sender;
            waitSpinner.ChangeVisualState(true);
        }
        public WaitSpinner()
        {
            DefaultStyleKey = typeof(WaitSpinner);
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            ChangeVisualState(false);
        }
        protected virtual void ChangeVisualState(bool useTransitions)
        {
            VisualStateManager.GoToState(this, IsWaiting ? IsWaitingStateName : NotWaitingStateName, useTransitions);
        }
    }
