    public static bool HasWritableProperty(this object objectToCheck, string propertyName)
    {
      var type = objectToCheck.GetType();
      //get a property info for the property, but only if it is a public instance property
      var pi = type.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public)
      //return false if no propery is found
      if (pi==null) return false;
      //get the set method for the property
      var setter = pi.GetSetMethod();
      //if it's null the property is not writable
      return (setter != null);
    }
