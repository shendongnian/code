    public static class TextChangedAttachedBehavior
    {
        public static bool GetChanged(DependencyObject obj)
        {
            return (bool)obj.GetValue(ChangedProperty);
        }
    
        public static void SetChanged(DependencyObject obj, string value)
        {
            obj.SetValue(ChangedProperty, value);
        }
    
        public static readonly DependencyProperty ChangedProperty =
            DependencyProperty.RegisterAttached("Changed", typeof(bool),
            typeof(TextChangedAttachedBehavior), new PropertyMetadata(false, HookupBehavior));
    
        private static void HookupBehavior(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var textBox = d as TextBox;
            if (textBox == null) 
                return;
            textBox.TextChanged += TextBoxOnTextChanged;
        }
    
        private static void TextBoxOnTextChanged(object sender, TextChangedEventArgs args)
        {
            var textBox = sender as TextBox;
            if (textBox == null)
                return;
            textBox.BorderBrush = new SolidColorBrush(Colors.Orange);
        }
    }
