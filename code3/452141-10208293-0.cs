    public string this[string propertyName]
    {
        get
        {
            string result = null;
            if (CanDataErrorValidated(propertyName))
            {
                int errorCount = CurrentValidationAdapter.ErrorCount();
                result = ValidateProperty(propertyName, GetValidateValue(propertyName));
                // if the error flag has been changed after validation
                if (errorCount != CurrentValidationAdapter.ErrorCount())
                {
                    RaisePropertyChanged(PropHasError);
                    RaisePropertyChanged(PropError);
                }
            }
            else
            {
                RaisePropertyChanged(PropHasError);
                RaisePropertyChanged(PropError);
            }
            return result;
        }
    }
