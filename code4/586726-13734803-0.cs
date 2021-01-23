    public event Action evt
    public void RaiseEvent()
    {
        var type = GetType();
        var fld = type.GetField("evt", BindingFlags.NonPublic | BindingFlags.Instance);
        var fldValue = (MulticastDelegate)fld.GetValue(this);
        fld.DynamicInvoke();
    }
