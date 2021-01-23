    bool nameIsValid = (!string.IsNullOrEmpty(name));
    if (useName)
    {
      if (!nameIsValid) 
        throw new SomeException("..."); 
    }
    else if (nameIsValid) 
    {
      throw new SomeException("..."); 
    }
