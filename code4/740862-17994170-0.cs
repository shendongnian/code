    _viewModel = new OrdersViewModel();
    if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
    {
        _viewModel.Orders = new ObservableCollection<OrderModel>()
        {
            new OrderModel(){OrderId = "0e2fa124"},
            new OrderModel(){OrderId = "5wqsdgew"},
        };
    };
