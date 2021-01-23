    private booly _isImageValid;
    public bool IsImageValid
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
