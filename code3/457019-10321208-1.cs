    public void EnsureConfigurationIsValid(string configFile, string programFile)
    {
        var exceptions = Validate(configFile, programFile).ToList();
        if(exceptions.Count > 0)
           throw new ValidationFailedException(exceptions); // creates an internal list
    }
