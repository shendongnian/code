    public void Dispose()
    {
        var fieldInfos = this.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy);
        foreach (var fieldInfo in fieldInfos)
        {
            var value = fieldInfo.GetValue(this);
            if (value is IDisposable)
            {
                ((IDisposable)value).Dispose();
                fieldInfo.SetValue(this, null);
            }
        }
        _baseDisposableB.Dispose();
    }
