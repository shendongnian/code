    BindingExpression binding = BindingOperations.GetBindingExpression(
                                          combo_range, 
                                          ComboBox.ItemsSourceProperty
                                );
    if (binding != null)
    {
         binding.UpdateTarget();
    }
