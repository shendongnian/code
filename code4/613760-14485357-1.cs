    var _attribute = Attribute.GetCustomAttribute(invocation.Method, typeof(OneToManyAttribute), true);
    if (_attribute == null && invocation.Method.IsSpecialName)
    {
       var property = PropertyInfoFromAccessor(invocation.Method);
       if (property != null)
       {
          _attribute = Attribute.GetCustomAttribute(property, typeof(OneToManyAttribute), true);
       }
    }
