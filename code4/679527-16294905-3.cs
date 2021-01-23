    public void SetProperty(Type t, object sender, string property, object value)
    {
      t.GetProperty(property).SetValue(sender, value, null);
    }
    public object GetPropertyValue(Type t, object sender, string property)
    {
      t.GetProperty(property).GetValue(sender, null);
    }
