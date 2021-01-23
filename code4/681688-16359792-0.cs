    MessageBinder.SpecialValues.Add("$originalsourcedatacontext", (context) =>
    {
        if (context.EventArgs is EventArgs)
        {          
            var e = context.EventArgs as EventArgs;
    
            // If the control is a FrameworkElement it will have a DataContext which contains the bound item
            var fe = e.OriginalSource as FrameworkElement;
    
            if (fe != null)
                return fe.DataContext;
        }
    
        return null;
    });
