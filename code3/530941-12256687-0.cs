    > public RelayCommand<object> DeletCommand { get; set; }
    > 
    > DeletCommand = new RelayCommand<object>(OnDelete, OnDeletCanExecute);
    > 
    > private void OnDelete(object obj) { }
    > 
    > private bool OnDeletCanExecute(object obj)  {
         return SelectedItemArchiveGrid != null;  }
