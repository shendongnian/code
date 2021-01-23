    public partial class MyUserControl : UserControl
    {
        public bool IsEditingMode
        {
            get { return (bool)GetValue(IsEditingModeProperty); }
            set { SetValue(IsEditingModeProperty, value); }
        }
        
        public static readonly DependencyProperty IsEditingModeProperty =
            DependencyProperty.Register("IsEditingMode", typeof(bool), typeof(MyUserControl), new PropertyMetadata(false, IsEditingModeChanged));
    }
    private static void IsEditingModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        // this will be called when someone would set the exposed property to some new value
    }
