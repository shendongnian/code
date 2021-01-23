    public static MyEntity Copy(this MyEntity source)
    {
        var result = new MyEntity();
        var properties = source.GetType().GetProperties(
              BindingFlags.Instance | BindingFlags.Public);
        foreach (var property in properties)
        {
            var val = property.GetValue(source, null);
            property.SetValue(result, val, null);
        }
        return result;
    }
