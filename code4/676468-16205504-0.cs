    public bool ToBoolean(string value)
    {
      var boolValue = false;
      if (bool.TryParse(value, out boolValue ))
      {
        return boolValue;
      }
    
      var number = 0;
      int.TryParse(value, out number))
      return Convert.ToBoolean(number);
    }
