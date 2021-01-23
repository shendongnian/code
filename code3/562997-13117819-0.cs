    public string this[string propertyName]
    {
        get
        {
            if (propertyName == "PhoneNumber")
            {
                if (!IsUSNumber(PhoneNumber))
                {
                    return "Non-US number.";
                }
            }
    
            // No validation errors found by the viewmodel
            // Forward to model's IDataErrorInfo implementation
            return Model[propertyName];
        }
    }
