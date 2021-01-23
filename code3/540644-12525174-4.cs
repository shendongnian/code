    public class MySampleAttachedProperty
    {
        public static string GetHeader(DependencyObject obj)
        {
            return (string)obj.GetValue(HeaderProperty);
        }
        public static void SetHeader(DependencyObject obj, string value)
        {
            obj.SetValue(HeaderProperty, value);
        }
        // Using a DependencyProperty as the backing store for Header.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.RegisterAttached("Header", typeof(string), typeof(MySampleAttachedProperty), new UIPropertyMetadata(CallBack));
        private static void CallBack(object sender, DependencyPropertyChangedEventArgs args)
        {
            TabControl tabControl = sender as TabControl;
            TabItem newTab = new TabItem { Header = args.NewValue };
            tabControl.Items.Add(newTab);
            newTab.Focus();
        }
    }
