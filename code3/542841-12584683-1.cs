    private string _signature = string.Empty;
    public string Signature 
        {
            get { return _signature; }
            set
            {
                if (_signature == value)
                    return;
                _signature = value;
                RaisePropertyChanged(Signature);
            }
        }
