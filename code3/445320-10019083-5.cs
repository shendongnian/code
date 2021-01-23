    // Iterate all public members using reflection
    foreach (MemberInfo mi in obj.GetType().GetMembers().Where(x => x is PropertyInfo || x is FieldInfo))
    {
      // Determine if decorated with MyAttribute.
      var attribs = mi.GetCustomAttributes(typeof(MyAttribute), true);
      if (attribs.Length == 1)
      {
        // Get value of property.
        object value = mi.CreateWrapper().GetValue(obj, null);
        DoAction(value);
      }
    }
