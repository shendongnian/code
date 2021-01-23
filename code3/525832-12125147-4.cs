    // Use this to trigger break into debugger when debugging another instance of Visual Studio in order to debug the behaviour at design time.
    System.Diagnostics.Debugger.Break();
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
