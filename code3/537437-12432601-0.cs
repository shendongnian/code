        foreach (var property in p.GetType().GetProperties())
        {
            var actualProperty = property.DeclaringType != property.ReflectedType ? property.DeclaringType.GetProperty(property.Name) : property;
            actualProperty.SetValue(p, newValue, null);
        }
