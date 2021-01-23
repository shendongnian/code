    foreach (PropertyInfo propertyInfo in your_class.GetType().GetProperties())
    {
      if ((info.PropertyType.IsEnum) && (info.PropertyType.IsPublic))
      {
        foreach (FieldInfo fInfo in this.propertyInfo.PropertyType.GetFields(BindingFlags.Public | BindingFlags.Static))
        {
          ListItem item = new ListItem(fInfo.Name, fInfo.GetRawConstantValue().ToString());
          //... use it
        }
      }
    }
