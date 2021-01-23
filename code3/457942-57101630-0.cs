    public static void CreateStyle(Type target, params (BindableProperty property, object value)[] setters)
            {
                Style style = new Style(target);
                foreach (var setter in setters)
                {
                   style.Setters.Add(new Setter
                   {
                       Property = setter.property,
                       Value = setter.value
                   });
                }
            }
