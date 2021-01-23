    interface IMessageBoxManager
    {
        MessageBoxResult ShowMessageBox(string text, string title,
                                        MessageBoxButtons buttons);
    }
    
    class MyViewModel
    {
        IMessageBoxManager _messageBoxManager;
       
        // ...
    
        public void Close()
        {
            if(HasUnsavedChanges)
            {
                var result = _messageBoxManager.ShowMessageBox(
                                 "Unsaved changes, save them before close?", 
                                 "Confirmation", MessageBoxButtons.YesNoCancel);
                if(result == MessageBoxResult.Yes)
                    Save();
                else if(result == MessageBoxResult.Cancel)
                    return; // <- Don't close window
                else if(result == MessageBoxResult.No)
                    RevertUnsavedChanges();
            }
    
            TryClose(); // <- Infrastructure method from Caliburn Micro
        }
    }
