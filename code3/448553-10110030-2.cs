    public void Validate(ValidationDictionary validationDictionary)
    {
        if (SomeProperty.Length > 30)
        {
            validationDictionary.AddError("SomeProperty", "SomeProperty max length is 30 chars");
        }
    }
