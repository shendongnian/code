    public void SomeMethod()
    {
        //do some work
        isDoSomethingButtonEnabled = true;
        DoSomethingCommand.RaiseCanExecuteChanged();
    }
