    protected override void Invoke(object parameter)
    {            
        base.Invoke(parameter);
        dynamic viewModel = PassedObject;
        Messenger.Default.Send(GetMessage(this, viewModel), NavigationToken);
    }
    
    private NavigatingMessage<T> GetMessage<T>(NavigateToPageAction action, T item)
    {
        return new NavigatingMessage<T>(action, item);
    }
