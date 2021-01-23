    public void Proc(object parameter1, object parameter2, string string1)
    {
        Validator.ThrowIfNull(() => parameter1);
        Validator.ThrowIfNull(() => parameter2);
        Validator.ThrowIfNullOrEmpty(() => string1);
        // Main code.
    }
