    public String CalculatorOutput
    {
        get { return _calculatorOutput; }
        set
        {
            _calculatorOutput = value;
            NotifyPropertyChanged();
        }
    }
