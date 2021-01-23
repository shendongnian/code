    public MyViewModelImplementation()
    {
       Add = new RelayCommand(AddItem);
    }
    
    private void AddItem()
    {
       DispatcherHelper.CheckBeginInvokeOnUI(() =>
       {
          Items.Add(new MyData());
       });
    }
