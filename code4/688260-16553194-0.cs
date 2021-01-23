    public bool CanBuild(SetOfData<SomeType> setofdata)
    {
        return validator.IsValid(setofdata);
    }
    
    public BusinessObject Build(SetOfData<SomeType> setofdata)
    {
        if (validator.IsValid(setofdata))
        {
            return new BusinessObject(setofdata);
        }
        throw new ArgumentException();
    }
	
