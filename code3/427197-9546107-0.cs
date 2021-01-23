        Binding binding = new Binding();
        binding.Source = GridGroup1;
        binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
        binding.Path = new PropertyPath("ActualHeight");
        MyGridBorder.SetBinding(Border.HeightProperty, binding);
