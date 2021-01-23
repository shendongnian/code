    if (_act == null) {
      _act = new RelayCommand(this.DoCommand, this.CanDoCommand);
    }
    private void DoCommand(object parameter)
    {
    }
    private bool CanDoCommand(object parameter)
    {
        if (Removed)
          Console.WriteLine("Why is this happening?");
        return true;
    }
