    private DateTime? _testDate = DateTime.Now;
    public DateTime? TestDate {
      get { return _testDate; }
      set {
        if (value < DateTime.Now)
          System.Windows.MessageBox.Show("BAD!");
        else
          _testDate = value;
        OnPropertyChanged("TestDate");
      }
    }
