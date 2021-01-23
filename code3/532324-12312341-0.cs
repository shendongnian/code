    public ReactiveCommand DeleteCommand { get; protected set; }
    private ReactiveAsyncCommand ExecuteDelete { get; protected set; }
    /*
     * In the Constructor
     */
    
    ExecuteDelete = new ReactiveAsyncCommand();
    ExecuteDelete.RegisterAsyncAction(() => /* Do the delete */);
    DeleteCommand = new ReactiveCommand(ExecuteDelete.CanExecuteObservable);
    DeleteCommand
        .Where(_ => MessageBox.Show("Delete?") == MessageBoxResult.Yes)
        .InvokeCommand(ExecuteDelete);
