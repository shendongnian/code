    public void SetProperty(string compoundProperty, object target, object value)
    {
        string[] bits = compoundProperty.Split('.');
        for (int i = 0; i < bits.Length - 1; i++)
        {
            PropertyInfo propertyToGet = target.GetType().GetProperty(bits[i]);
            target = propertyToGet.GetValue(target, null);
        }
        PropertyInfo propertyToSet = target.GetType().GetProperty(bits.Last());
        propertyToSet.SetValue(target, value, null);
    }
