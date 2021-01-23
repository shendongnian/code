    static void RestrictedComboBox_Loaded
        (object sender, RoutedEventArgs e) {
        ComboBox cb = (ComboBox)sender;
        BindingExpression be = cb.GetBindingExpression
            (ComboBox.TextProperty);
        if (be != null) {
            Binding b = be.ParentBinding;
            b.ValidationRules.Add
                (new RestrictedComboBoxItemValidationRule
                    ((ComboBox)sender)); } }
