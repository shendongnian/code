    private static void OnChangedRestricted(DependencyObject o, DependencyPropertyChangedEventArgs e) {
            Control c = o as Control;
            if (c != null && (bool)e.NewValue == true) {
                if (c.GetType() == typeof(ComboBox)) {
                    ((ComboBox)c).Loaded += new RoutedEventHandler(RestrictedComboBox_Loaded);
