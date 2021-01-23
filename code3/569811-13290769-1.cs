    public void Dispose()
    {
        var type = GetType();
        while (type != null)
        {
            DisposeFields(type);
            type = type.BaseType;
        }
    }
    private void DisposeFields(Type type)
    {
        var fieldInfos = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
        foreach (var fieldInfo in fieldInfos)
        {
            var value = fieldInfo.GetValue(this) as IDisposable;
            if (value == null) continue;
            value.Dispose();
            fieldInfo.SetValue(this, null);
        }
    }
