    ViewPortViewModel _Trochoid;
    public ViewPortViewModel Trochoid
    {
        get { return _Trochoid; }
        set { this.RaiseAndSetIfChanged(ref _Trochoid, value); }
    }
