    public class MetalTransactionViewModel : WorkspaceViewModel
    {
        private RelayCommand _deleteCommand;
    
        IList<MetalTransactionViewModel> ParentCollection { get; }
    
    public RelayCommand DeleteCommand
        {
            get
            {
                return _deleteCommand
                       ?? (_deleteCommand = new RelayCommand(
                            () =>
                                {
                                    if (!IsNewUnit)
                                    {
                                        _dataService.DeleteMetalTransaction(_metalTransaction, CallbackDelete);
                                        _dataService.CommitAllChanges(delegate(bool b, object o) {  });
    
                                         if (ParentCollection == null) { return; }
    if (ParentCollection.Contains(this)) { ParentCollection.Remove(this); }
                                    }
                                },
                            () => !IsNewUnit));
            }
        }
    
    }
