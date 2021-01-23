    private System.Windows.Visibility _isImageValid; //add this code in my viewmodel
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
