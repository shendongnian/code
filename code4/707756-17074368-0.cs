    GetLogicalChildCollection<RadioButton>(mainPanel).ForEach(
        rb =>
        {
            var binding = new Binding
            {
                Path = new PropertyPath(RadioButton.IsCheckedProperty),
                Source = rb
            };               
            rb.SetBinding(RadioChecker.IsCheckedProperty, binding);
        });
