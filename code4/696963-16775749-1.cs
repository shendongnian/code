    private string _currentScanVMKey;
    public ScanViewModel Scan
    {
      get {
        if (!string.IsNullOrEmpty(_currentScanVMKey))
          SimpleIoc.Default.Unregister(_currentScanVMKey);
        _currentScanVMKey = Guid.NewGuid().ToString();
        return ServiceLocator.Current.GetInstance<ScanViewModel>(_currentScanVMKey);
      }
    }
