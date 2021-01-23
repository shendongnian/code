    protected override void PostDeserialize()
    {
        base.PostDeserialize();
        if (FirstSubTypeConfig != null && SecondTypeCOnfig != null)
        {
            throw new ConfigurationErrorsException("Only an element is allowed.");
        }
    }
