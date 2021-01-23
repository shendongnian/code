     if (value.Length > 50)
        {
          throw new ValueLengthExceededException("Email", 
            localization.GetString("toolong_email"));
        }
        else if (!IsValidEmail(value))
        {
          /* 
            Or a generic "InvalidFormatException/FormatException" with 
            member name like a previous example. 
          */
          throw new InvalidEmailException(localization.GetString("invalid_email")); 
        }
