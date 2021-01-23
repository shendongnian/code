    private CalculationViewModel _model;
    public CalculationViewModel Model
    {
        get { return _model; };
        set
        {
            if (_model != null) _model.ResultChanged -= Refresh;
            _model = value;
            _model.ResultChanged += Refresh;
        };
    }
    public void Refresh()
    {
        // display the result
    }
