    public void SetParam(string element, string property, dynamic value)
    {
        FieldInfo field = typeof(Form1).GetField(element, BindingFlags.NonPublic | BindingFlags.Instance);
        object control = field.GetValue(this);
        control.GetType().GetProperty(property).SetValue(control, value, null);
    }
