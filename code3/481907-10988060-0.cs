    public class ExpanderBehavior
    {
        public static DependencyProperty BindToggleButtonVisibilityProperty =
            DependencyProperty.RegisterAttached("BindToggleButtonVisibility",
                                                typeof(bool),
                                                typeof(ExpanderBehavior),
                                                new PropertyMetadata(false, OnBindToggleButtonVisibilityChanged));
        public static bool GetBindToggleButtonVisibility(Expander expander)
        {
            return (bool)expander.GetValue(BindToggleButtonVisibilityProperty);
        }
        public static void SetBindToggleButtonVisibility(Expander expander, bool value)
        {
            expander.SetValue(BindToggleButtonVisibilityProperty, value);
        }
        private static void OnBindToggleButtonVisibilityChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
        {
            Expander expander = target as Expander;
            if (expander.IsLoaded == true)
            {
                BindToggleButtonVisibility(expander);
            }
            else
            {
                RoutedEventHandler loadedEventHandler = null;
                loadedEventHandler = new RoutedEventHandler(delegate
                {
                    BindToggleButtonVisibility(expander);
                    expander.Loaded -= loadedEventHandler;
                });
                expander.Loaded += loadedEventHandler;
            }
        }
        private static void BindToggleButtonVisibility(Expander expander)
        {
            ToggleButton headerSite = expander.Template.FindName("HeaderSite", expander) as ToggleButton;
            if (headerSite != null)
            {
                Binding visibilityBinding = new Binding
                {
                    Source = expander,
                    Path = new PropertyPath(ToggleButtonVisibilityProperty)
                };
                headerSite.SetBinding(ToggleButton.VisibilityProperty, visibilityBinding);
            }
        }
        #region ToggleButtonVisibilityProperty
        public static DependencyProperty ToggleButtonVisibilityProperty = 
            DependencyProperty.RegisterAttached("ToggleButtonVisibility",
                                                typeof(Visibility),
                                                typeof(ExpanderBehavior),
                                                new PropertyMetadata(Visibility.Visible));
        public static Visibility GetToggleButtonVisibility(Expander expander)
        {
            return (Visibility)expander.GetValue(ToggleButtonVisibilityProperty);
        }
        public static void SetToggleButtonVisibility(Expander expander, Visibility value)
        {
            expander.SetValue(ToggleButtonVisibilityProperty, value);
        }
        #endregion // ToggleButtonVisibilityProperty
    }
