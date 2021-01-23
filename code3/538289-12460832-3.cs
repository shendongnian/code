    #region IDataErrorInfo & Validation Members
        
    #region Validation Delegate
    
    public delegate string ValidationDelegate(
        object sender, string propertyName);
    
    private List<ValidationDelegate> _validationDelegates = 
        new List<ValidationDelegate>();
    
    public void AddValidationDelegate(ValidationDelegate func)
    {
        _validationDelegates.Add(func);
    }
    
    public void RemoveValidationDelegate(ValidationDelegate func)
    {
        if (_validationDelegates.Contains(func))
            _validationDelegates.Remove(func);
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
        string s = null;
    
        foreach (var func in _validationDelegates)
        {
            s = func(this, propertyName);
            if (s != null)
                return s;
        }
    
        return s;
    }
    
    #endregion // IDataErrorInfo for binding errors
        
    #endregion // IDataErrorInfo & Validation Members
