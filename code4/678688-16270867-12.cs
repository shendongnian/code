    public ActionsViewModel()
    {
       //Existing code here
        AddActionCommand = new Command(AddAction);
        DeleteActionCommand = new Command(DeleteAction);
        RunCommand = new Command(Run);
    }
