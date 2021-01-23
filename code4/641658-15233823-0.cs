    private InputParametersProperty _inputParameters;
    public InputParametersProperty InputParameters
    {
        get
        {
            return _inputparameters ?? (_inputparameters = new InputParametersProperty()); 
        }
    }
