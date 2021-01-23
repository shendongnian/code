    public string NotNullString { 
       get { return _NotNullString; }
       set { 
              if(UseValidation && (String.IsNullOrEmpty(value) || value.Length > 15)) {
                  throw new Exception("Value must be between 1 and 15 characters long.");
              }
              _NotNullString = value;
           }
    }
