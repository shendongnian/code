    void propertyGrid1_SelectedGridItemChanged(object sender, SelectedGridItemChangedEventArgs e)
        {
            if (e.NewSelection != null &&
                e.NewSelection.PropertyDescriptor != null &&
                e.NewSelection.PropertyDescriptor.Converter != null &&
                e.NewSelection.PropertyDescriptor.Converter.GetStandardValuesExclusive() == true)
            {
                System.Reflection.FieldInfo field_gridView = propertyGrid1.GetType().GetField("gridView", System.Reflection.BindingFlags.NonPublic
                    | System.Reflection.BindingFlags.Instance);
                object gridView = field_gridView.GetValue(propertyGrid1);                
                System.Reflection.MethodInfo gridView_methode_get_DropDownButton = gridView.GetType().GetMethod("get_DropDownButton", System.Reflection.BindingFlags.NonPublic
                    | System.Reflection.BindingFlags.Instance);
                object dropdownbutton = gridView_methode_get_DropDownButton.Invoke(gridView, new object[0]);
                System.Reflection.MethodInfo dropdownbutton_method_OnClick = dropdownbutton.GetType().GetMethod("OnClick", System.Reflection.BindingFlags.NonPublic
                    | System.Reflection.BindingFlags.Instance);
                dropdownbutton_method_OnClick.Invoke(dropdownbutton, new object[] { new System.EventArgs() });
            }
        }
