    using GalaSoft.MvvmLight;
    ...
    public MainWindow() {
      InitializeComponent();
      if (ViewModelBase.IsInDesignModeStatic)
        DataContext = new MainViewModel();
    }
