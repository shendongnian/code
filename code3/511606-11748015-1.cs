    public static TValue GetDefaultValue<TClass, TValue>(Expression<Func<TClass, TValue>> getter) {
        var type = typeof(TClass);
        var property = type.GetProperties().ToList().Single(p => p.Name == GetFullPropertyName(exp));
        var defaultValue = (DefaultValueAttribute)property.GetCustomAttributes(typeof(DefaultValueAttribute), false).FirstOrDefault();
        return (TProperty)defaultValue.Value;
    }
