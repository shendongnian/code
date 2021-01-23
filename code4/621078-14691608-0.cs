    // You need these instances
    var yourViewModel = GetTheViewModel();
    var yourView = GetYourView();
    Binding binding = new Binding("IsRequired");
    binding.Source = yourViewModel;
    binding.Mode = BindingMode.TwoWay;
    yourView.SetBinding(YourViewType.IsRequiredProperty, binding);
