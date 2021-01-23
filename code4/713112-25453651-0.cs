    private bool CanExecuteSaveCommand()
        {
            return SelectedOrder.ContactName != null;
        }
    private void ExecuteSaveCommand()
        {
            Save();
        }
