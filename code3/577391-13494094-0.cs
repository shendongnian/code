    public async Task SaveAsync(MyData data) { ... }
    // Logically, this is an asynchronous ICommand.Execute implementation.
    public async void SaveCommand()
    {
      saveInProgress = true;
      dirty = false;
      MyData data = CopyData();
      await SaveAsync(data);
      saveInProgress = false;
    }
    // Logically, this is an ICommand.CanExecute implementation.
    public bool CanSave { get { return !saveInProgress && dirty; } }
    private bool saveInProgress, dirty;
