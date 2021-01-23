    private ObservableCollection<string> _drives = new ObservableCollection<string>();
    public ObservableCollection<string> Drives {
      get { return _drives; }
      set {
        _drives = value;
        this.raisePropertyChanged("Drives");
      }
    }
