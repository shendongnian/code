    public void Validate(ValidationDictionary validationDictionary)
    {
        if (SomeProperty.Length > 30)
        {
            validationDictionary.AddError("SomeProperty", "Max length is 30 chars");
        }
    }
