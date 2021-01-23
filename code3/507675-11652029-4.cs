    public static class ButtonBehaviors
    {
        public static object GetButtonDoubleClick(DependencyObject obj)
        {
            return obj.GetValue(ButtonDoubleClickProperty);
        }
        public static void SetButtonDoubleClick(DependencyObject obj, object value)
        {
            obj.SetValue(ButtonDoubleClickProperty, value);
        }
        public static readonly DependencyProperty ButtonDoubleClickProperty =
            DependencyProperty.RegisterAttached("ButtonDoubleClick", typeof (object), typeof (ButtonBehaviors),
                                                new UIPropertyMetadata(new PropertyChangedCallback(OnButtonDoubleClickChanged)));
        private static void OnButtonDoubleClickChanged (DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var button = d as Button;
            if(button == null)
            {
                return;
            }
            var command = e.NewValue as ICommand;
            if(command == null)
            {
                return;
            }
            button.MouseDoubleClick += (o, ev) => command.Execute(button);
        }
    }
