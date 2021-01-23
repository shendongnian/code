    if (d2.ConstructorArguments.Count == 1)
    {
      var mode = d2.ConstructorArguments[0].Value as DebuggableAttribute.DebuggingModes;
      // Parse the modes enumeration and figure out the values.
    }
    else
    {
      var tracking = (bool)d2.ConstructorArguments[0].Value;
      var optimized = !((bool)d2.ConstructorArguments[1].Value);
    }
        
