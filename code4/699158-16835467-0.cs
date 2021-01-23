    public static object SetStringPropertiesOnly(object obj)
    {
      //Get a list of properties where the declaring type is string
      var stringProps = obj.GetType().GetProperties().Where(x => x.PropertyType == typeof(string)).ToArray();
      foreach (var stringProp in stringProps)
      {
        //Do what you need to do
        stringProp.SetValue(obj, "value", null);
      }
      //What do you want to return?
      return obj;
    }
