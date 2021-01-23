    #region IDataErrorInfo & Validation Members
    
    /// <summary>
    /// List of Property Names that should be validated.
    /// Usually populated by the Model's Constructor
    /// </summary>
    protected List<string> ValidatedProperties = new List<string>();
    
    #region Validation Delegate
    
    public delegate string ValidationErrorDelegate(
        object sender, string propertyName);
    
    private List<ValidationErrorDelegate> _validationDelegates = new List<ValidationErrorDelegate>();
    
    public void AddValidationErrorDelegate(
        ValidationErrorDelegate func)
    {
        _validationDelegates.Add(func);
    }
    
    #endregion // Validation Delegate
    
    #region IDataErrorInfo for binding errors
    
    string IDataErrorInfo.Error { get { return null; } }
    
    string IDataErrorInfo.this[string propertyName]
    {
        get { return this.GetValidationError(propertyName); }
    }
    
    public string GetValidationError(string propertyName)
    {
        // Check to see if this property has any validation
        if (ValidatedProperties.IndexOf(propertyName) >= 0)
        {
            string s = null;
    
            foreach (var func in _validationDelegates)
            {
                s = func(this, propertyName);
                if (s != null)
                    return s;
            }
        }
    
        return s;
    }
    
    #endregion // IDataErrorInfo for binding errors
    
    #region IsValid Property
    
    public bool IsValid
    {
        get
        {
            return (GetValidationError() == null);
        }
    }
    
    public string GetValidationError()
    {
        string error = null;
    
        if (ValidatedProperties != null)
        {
            foreach (string s in ValidatedProperties)
            {
                error = GetValidationError(s);
                if (error != null)
                    return error;
            }
        }
    
        return error;
    }
    
    #endregion // IsValid Property
    
    #endregion // IDataErrorInfo & Validation Members
