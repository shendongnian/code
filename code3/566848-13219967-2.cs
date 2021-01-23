    public void RegisterForNotification(string propertyName, FrameworkElement element, PropertyChangedCallback callback)
        {
            Binding b = new Binding(propertyName) { Source = element };
            var prop = System.Windows.DependencyProperty.RegisterAttached(
                "ListenAttached" + propertyName,
                typeof(object),
                typeof(UserControl),
                new System.Windows.PropertyMetadata(callback));
            element.SetBinding(prop, b);
        }
