    private bool _IsSessionEnabled;
    public bool IsSessionEnabled
    {
        get { return _IsSessionEnabled; }
        set {
            if (_IsSessionEnabled != value) {
                _IsSessionEnabled = value;
                this.OnPropertyChanged();
                this.switchSession(value); /* this is your session code */
            }
        }
    }
