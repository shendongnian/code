    public class SmartTextBox : TextBox
    {
        public static readonly DependencyProperty IsSelectedTextProperty = DependencyProperty.RegisterAttached("IsSelectedText",
            typeof(bool), typeof(SmartTextBox), new FrameworkPropertyMetadata(false, OnIsSelectedChanged));
        public bool IsSelectedText
        {
            get { return (bool)GetValue(IsSelectedTextProperty); }
            set { SetValue(IsSelectedTextProperty, value); }
        }
        private static void OnIsSelectedChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            SmartTextBox textbox = sender as SmartTextBox;
            if ((bool)e.NewValue)
            {
                textbox.Focus();
                textbox.SelectAll();
            }
        }
    }
