    // Iterate all public members using reflection
    foreach (MemberInfo pi in obj.GetType().GetMembers().Where(x => x is PropertyInfo || x is FieldInfo))
    {
      // Determine if decorated with MyAttribute.
      var attribs = pi.GetCustomAttributes(typeof(MyAttribute), true);
      if (attribs.Length == 1)
      {
        // Get value of property.
        object value = pi.CreateWrapper().GetValue(obj, null);
        DoAction(value);
      }
    }
