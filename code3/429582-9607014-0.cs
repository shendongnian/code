    public void VerifyData(ValidationErrors errors)
    {
      ValidateFileExists(errors);
      ValidateExtension(errors);
      ValidateFileAccess(errors);
      ...
    }
    
    private void ValidateFileExists(ValidationErrors errors)
    {
     if(!File.Exists...)
    {
      errors.Add("File does not exists.");
    }
    }
    
    public void CallingMethod(UserInput input)
    {
      _dataToVerify = input;
      var errors = new ValidationErrors();
      VerifyData(errors);
      if(errors.Count > 0)
       ShowErrors(errors);
      else
       ShowSuccess();
    }
