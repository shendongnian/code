    private async void SaveCommandExecute()
    {
      try
      {
        // Set VM property; updates View appropriately.
        Busy = true;
        // Do the actual saving asynchronously.
        await Model.SaveAsync();
      }
      catch (Exception ex)
      {
        // Update the VM with error information.
        Error = ex.Message;
      }
      finally
      {
        // Let the VM know we're done.
        Busy = false;
      }
    }
    private void SaveCommandCanExecute()
    {
      return !Busy;
    }
