    public void SetProperty(ref object sender, string property, object value)
    {
      sender.GetProperty(property).SetValue(sender, value, null);
    }
    public object GetPropertyValue(object sender, string property)
    {
      sender.GetProperty(property).GetValue(sender, null);
    }
