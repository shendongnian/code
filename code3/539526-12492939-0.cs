    public Type Type { get; set; }
    public string PropertyName { get; set; }
    ProvideValue: Type.GetProperty(PropertyName)
                      .GetCustomAttributes(true)
                      .OfType<Description>()
                      .First()
                      .Description
