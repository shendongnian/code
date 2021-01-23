    void AssociatedObject_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        // if you want to pass a command param to CanExecute, need to add another dependency property to bind to
        if (TabCommand != null && e.Key == Key.Tab && TabCommand.CanExecute(null))
        {
            TabCommand.Execute(null);
            e.Handled = true;
        }
    }
