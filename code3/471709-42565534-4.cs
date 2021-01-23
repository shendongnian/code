    public abstract class ValidatorBase : IDataErrorInfo
    {
      string IDataErrorInfo.Error
      {
        get
        {
          throw new NotSupportedException("IDataErrorInfo.Error is not supported, use IDataErrorInfo.this[propertyName] instead.");
        }
      }
      string IDataErrorInfo.this[string propertyName]
      {
        get
        {
          if (string.IsNullOrEmpty(propertyName))
          {
            throw new ArgumentException("Invalid property name", propertyName);
          }
          string error = string.Empty;
          var value = GetValue(propertyName);
          var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>(1);
          var result = Validator.TryValidateProperty(
              value,
              new ValidationContext(this, null, null)
              {
                MemberName = propertyName
              },
              results);
          if (!result)
          {
            var validationResult = results.First();
            error = validationResult.ErrorMessage;
          }
          return error;
        }
      }
      private object GetValue(string propertyName)
      {
        PropertyInfo propInfo = GetType().GetProperty(propertyName);
        return propInfo.GetValue(this);
      }
    }
