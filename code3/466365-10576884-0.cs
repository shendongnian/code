    var binding = new Binding();
    binding.Source = attribute;
    binding.Path = new PropertyPath("Visible");
    binding.Converter = (BooleanToVisibilityConverter)Resources["BoolToVisibilityConverter"];
    
    BindingOperations.SetBinding(column, DataGridTemplateColumn.VisibilityProperty, binding);
