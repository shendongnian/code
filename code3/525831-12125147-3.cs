    if (dependencyObject != null)
    {
        var view = GetLocateFor( dependencyObject ); // or instead of this access the changed value through the eventargs
        var viewModelName = view.GetType().AssemblyQualifiedName;
        
        if (! string.IsNullOrEmpty(viewModelName))
        {
            viewModelName = viewModelName.Replace("View", "ViewModel");
            var viewModel = DependencyLocator.GetInstance(Type.GetType(viewModelName));
            if (viewModel != null)
            {
               ((FrameworkElement) view ).DataContext = viewModel;
            }
        }
    }
