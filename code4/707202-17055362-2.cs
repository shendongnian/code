    public const string ElementVisibilityPropertyname = "ElementVisibility";
    private Visibility _elementVisibility = Visibility.Collapsed;
    public Visibility ElementVisibility
    {
        get
        {
            return _elementVisibility;
        }
        set
        {
            if (_elementVisibility== value)
            {
                return;
            }
            RaisePropertyChanging(ElementVisibilityPropertyname );
            _elementVisibility= value;
            RaisePropertyChanged(ElementVisibilityPropertyname );
        }
    }
