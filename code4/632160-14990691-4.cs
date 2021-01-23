    if (!this.TryCheckHeaderName(name))
    {
        return false;
    }
    if (value == null)
    {
        value = string.Empty;
    }
    AddValue(this.GetOrCreateHeaderInfo(name, false), value, StoreLocation.Raw);
    return true;
