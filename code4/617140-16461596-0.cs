    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      var mp = parameter as MetadataParameters;
      var modelPropertyInfo = mp.ModelType.GetProperty(mp.ModelProperty);
      var attribute = modelPropertyInfo
          .GetCustomAttributes(true)
          .Cast<Attribute>()
          .FirstOrDefault(memberInfo => memberInfo.GetType() == mp.AttributeType);
      // We have to call the GetXXX methods on the attribute to get a localised result.
      //return ((DisplayAttribute)attribute).GetName();
      var result = attribute
        .GetType()
        .InvokeMember(
          "Get" + mp.AttributeProperty,
          BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.Public,
          null,
          attribute,
          new object[0]); 
      return result;
    }
