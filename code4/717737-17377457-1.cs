    class NotNullOrEmptyValidationRule : IValidationRule
    {
      public string ErrorMessage { get; private set; }
    
      public bool Validate(object value)
      {
        string valueText = value as string;
     
        if (string.IsNullOrEmpty(valueText))
        {
          ErrorMessage = Resources.NotNullValidationRule_Error;
          return false;
        }
     
        ErrorMessage = string.Empty;
        return true;
      } 
    }
