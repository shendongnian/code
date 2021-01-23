    var viewModel = new CustomerViewModel();
    
    var systemViewModelPropertyInfo = viewModel.GetType()
        .GetProperties()
        .FirstOrDefault(p => p.PropertyType == typeof(SystemViewModel));
    
    if (systemViewModelPropertyInfo != null) {
        var systemViewModelProperty = systemViewModelPropertyInfo.GetValue(viewModel, null) as SystemViewModel;
    
        // get the desired value of isReadOnly here...
        var isReadOnly = false;
    
        // here, systemViewModelProperty may be null if it has not been set.
        // You can decide what to do in that case. If you need a value to be
        // present, you'll have to do something like this...
        if (systemViewModelProperty == null) {
            systemViewModelPropertyInfo.SetValue(viewModel, new SystemViewModel { isReadOnly = isReadOnly }, null);
        }
        else {
            systemViewModelProperty.isReadOnly = isReadOnly;
        }
    }
