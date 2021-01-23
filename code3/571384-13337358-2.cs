    private int _myProperty;
    public int MyProperty
    {
        get
        {
            return _myProperty;
        }
        set
        {
            _myProperty = value;
            // See if the value can be parsed to an int.
            int potentialInt;
            if(int.TryParse(_myProperty, out potentialInt))
            {
                // If it can, execute your command with any needed parameters.
                yourCommand.Execute(_possibleParameter)
            }
        }
    }
