    ViewLocator.LocateForModel = (model, displayLocation, context) =>
    {
        var viewAware = model as IViewAware;
        
        // Added these 3 lines - the rest is from CM source
        // Try cast the model to IProvideContext
        var provideContext = model as IProvideContext;
        // Check if the cast succeeded, and if the context wasn't already set (by attached prop), if we're ok, set the context to the models context property
        if (provideContext != null && context == null)
             context = (model as IProvideContext).Context;
       
        if (viewAware != null)
        {                    
            var view = viewAware.GetView(context) as UIElement;
            if (view != null)
            {
    #if !SILVERLIGHT && !WinRT
                var windowCheck = view as Window;
                if (windowCheck == null || (!windowCheck.IsLoaded && !(new WindowInteropHelper(windowCheck).Handle == IntPtr.Zero)))
                {
                    LogManager.GetLog(typeof(ViewLocator)).Info("Using cached view for {0}.", model);
                    return view;
                }
    #else
                LogManager.GetLog(typeof(ViewLocator)).Info("Using cached view for {0}.", model);
                return view;
    #endif
            }
        }
        return ViewLocator.LocateForModelType(model.GetType(), displayLocation, context);
    };
