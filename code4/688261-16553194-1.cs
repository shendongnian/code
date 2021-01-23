    public bool TryBuild(SetOfData<SomeType> setofdata, out BusinessObject businessObject)
    {
        if (validator.IsValid(setofdata))
        {
            businessObject = new BusinessObject(setofdata);
            return true;
        }
        businessObject = null;
        return false;
    }
