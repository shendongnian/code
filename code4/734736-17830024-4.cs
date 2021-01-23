    public override string DisplayName
    {
      get
      {
        var property = Instance.GetType().GetProperty(DisplayNameValue);
        return property.GetValue(Instance, null) as string;
      }
    }
