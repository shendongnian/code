    public class myViewModel
    {
    
      ...
      ...
    
      public void ClearFields()
      {
        Type type = typeof(myViewModel);
        PropertyInfo[] pi = type.GetProperties();
        foreach (var pinfo in pi)
        {
          object[] attributes = pinfo.GetCustomAttributes(typeof(DefaultValueAttribute), false);
          if (attributes.Length > 0)
          {
            DefaultValueAttribute def = attributes[0] as DefaultValueAttribute;
            pinfo.SetValue(this, def.Value, null);
          }
        }
    
      }
    
      ...
      ...
    
    }
