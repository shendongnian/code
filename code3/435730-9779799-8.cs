    public class Mover : DependencyObject
    {
        public static readonly DependencyProperty MoveToMiddleProperty =
            DependencyProperty.RegisterAttached("MoveToMiddle", typeof (bool), typeof (Mover),
            new PropertyMetadata(false, PropertyChangedCallback));
        public static void SetMoveToMiddle(UIElement element, bool value)
        {
            element.SetValue(MoveToMiddleProperty, value);
        }
        public static bool GetMoveToMiddle(UIElement element)
        {
            return (bool) element.GetValue(MoveToMiddleProperty);
        }
        private static void PropertyChangedCallback(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;
            if (element == null)
            {
                return;
            }
            if ((bool)e.NewValue)
            {
                MultiBinding multiBinding = new MultiBinding();
                multiBinding.Converter = new CenterConverter();
                multiBinding.Bindings.Add(new Binding("ActualWidth") {Source = element});
                multiBinding.Bindings.Add(new Binding("ActualHeight") {Source = element});
                element.SetBinding(FrameworkElement.MarginProperty, multiBinding);
            }
            else
            {
                element.ClearValue(FrameworkElement.MarginProperty);
            }
        }
    }
