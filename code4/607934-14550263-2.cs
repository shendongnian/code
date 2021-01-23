    public static class ComboboxHelper
    {
        public static readonly DependencyProperty BindedTextProperty = DependencyProperty.RegisterAttached("BindedText", typeof(string), typeof(ComboboxHelper));
    
        public static string GetBindedText(DependencyObject obj)
        {
            string s = (string)obj.GetValue(BindedTextProperty);
            s = s.Replace(Environment.NewLine, " ");
            return s;
        }
    
        public static void SetBindedText(DependencyObject obj, string value)
        {
            obj.SetValue(BindedTextProperty, value);
        }
    }
