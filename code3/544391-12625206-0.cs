    HashTable<DependencyObject> current = new HashTable<DependencyObject>();
    // Bound as before
    private static void IsDefaultChanged(
        DependencyObject dependencyObject,
        DependencyPropertyChangedEventArgs args)
    {
        if ((bool)args.NewValue)
            current.Add(dependencyObject);
        else
            current.Remove(dependencyObject);
    }
    // Permanently bound, once.
    private static void CoreWindowOnKeyUp(CoreWindow sender, KeyEventArgs args)
    {
        foreach(var do in current)
        {
            ((ICommand)do.GetValue(Button.CommandProperty)).Execute(null);
        }
    }
