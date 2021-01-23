    public ICommand DeleteRangfolgeCommand
    {
      get
      {
         return new ActionCommand<MyOwnViewModel>(ExecuteDelete);
      }
    }
    private void ExecuteDelete(MyOwnViewModel viewModelToDelete)
    {
        this.ItemsSourceList.Remove(viewModelToDelete);
    }
