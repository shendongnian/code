    private System.Windows.Visibility _isImageValid;
    public System.Windows.Visibility IsImageValid
    {
        get
        { 
            return _isImageValid;
        }
        set
        {
            _isImageValid = value;
            this.RaisePropertyChanged(() => this.IsImageValid);
        }
    }
