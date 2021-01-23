            // Create template
            DataTemplate newTemplate = new DataTemplate();
            FrameworkElementFactory stackFactory = new FrameworkElementFactory(typeof(StackPanel));
            FrameworkElementFactory comboFactory = new FrameworkElementFactory(typeof(ComboBox));
            Binding newBinding = new Binding();
            newBinding.Source = Enum.GetNames(typeof(enumAttribute.EnumerationType));
            comboFactory.SetBinding(ComboBox.ItemsSourceProperty, newBinding);
            stackFactory.AppendChild(comboFactory);
            newTemplate.VisualTree = stackFactory;
  
            // Set the template
            templateColumn.CellTemplate = newTemplate;
