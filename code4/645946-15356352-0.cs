    private UserControl _currentControl;
    public MainWindowVirwModel()
    {
      CurrentControl = new HomePage();
    }
    public UserControl CurrentControl
    {
      get { return _curentControl;}
      set { this.RaiseAndSetIfChanged(...); }
    }
