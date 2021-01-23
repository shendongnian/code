    public List<KeyValuePair<string, object>> GetPropertiesRecursive(object instance)
    {
      List<KeyValuePair<string, object>> propValues = new List<KeyValuePair<string, object>>();
      foreach(PropertyInfo prop in instance.GetType().GetProperties())
      {
        propValues.Add(new KeyValuePair<string, object>(prop.Name, prop.GetValue(instance, null));
        propValues.AddRange(GetPropertiesRecursive(prop.GetValue(instance));
      }
    }
