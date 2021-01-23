    public static TControl SetContent<TControl>(this TControl obj, object val)
    where TControl : ContentControl
    { 
        obj.Content = val; 
        return obj; 
    }
