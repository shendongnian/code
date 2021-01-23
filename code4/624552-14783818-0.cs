    public ObservableCollection<int> Integers
    {
        get { return this.integers; }
        set {
            if (this.integers != value)
            {
                this.integers = value;
                RaisePropertyChanged("Integers");
            }
        }
    }
