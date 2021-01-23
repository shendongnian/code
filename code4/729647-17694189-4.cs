    internal static class Behaviours
    {
        public static readonly DependencyProperty SaveCanvasProperty =
            DependencyProperty.RegisterAttached("SaveCanvas", typeof(bool), typeof(Behaviours),
                                                new UIPropertyMetadata(false, OnSaveCanvas));
        public static void SetSaveCanvas(DependencyObject obj, bool value)
        {
            obj.SetValue(SaveCanvasProperty, value);
        }
        public static bool GetSaveCanvas(DependencyObject obj)
        {
            return (bool)obj.GetValue(SaveCanvasProperty);
        }
        private static void OnSaveCanvas(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue)
            {
                // Save code.....
            }
        }
    }
