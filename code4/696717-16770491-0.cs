    public static class InputTextBoxBindingsManager
    {
        public static readonly DependencyProperty UpdatePropertySourceWhenKeyPressedProperty = DependencyProperty.RegisterAttached(
                "UpdatePropertySourceWhenKeyPressed", typeof(DependencyProperty), typeof(InputTextBoxBindingsManager), new PropertyMetadata(null, OnUpdatePropertySourceWhenKeyPressedPropertyChanged));
        static InputTextBoxBindingsManager()
        {
        }
        public static void SetUpdatePropertySourceWhenKeyPressed(DependencyObject dp, DependencyProperty value)
        {
            dp.SetValue(UpdatePropertySourceWhenKeyPressedProperty, value);
        }
        public static DependencyProperty GetUpdatePropertySourceWhenKeyPressed(DependencyObject dp)
        {
            return (DependencyProperty)dp.GetValue(UpdatePropertySourceWhenKeyPressedProperty);
        }
        private static void OnUpdatePropertySourceWhenKeyPressedPropertyChanged(DependencyObject dp, DependencyPropertyChangedEventArgs e)
        {
            UIElement element = dp as UIElement;
            if (element == null)
            {
                return;
            }
            if (e.OldValue != null)
            {
                element.KeyUp -= HandlePreviewKeyDown;
            }
            if (e.NewValue != null)
            {
                element.KeyUp += new KeyEventHandler(HandlePreviewKeyDown);
            }
        }
        static void HandlePreviewKeyDown(object sender, KeyEventArgs e)
        {
            DoUpdateSource(e.Source);
        }
        static void DoUpdateSource(object source)
        {
            DependencyProperty property =
                GetUpdatePropertySourceWhenKeyPressed(source as DependencyObject);
            if (property == null)
            {
                return;
            }
            UIElement elt = source as UIElement;
            if (elt == null)
            {
                return;
            }
            BindingExpression binding = BindingOperations.GetBindingExpression(elt, property);
            if (binding != null)
            {
                binding.UpdateSource();
            }
        }
    }
