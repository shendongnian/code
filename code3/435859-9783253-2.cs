    object value = myObject.GetType().GetProperty(nameOfPropertyToset).GetValue(myObject, null);
    if (value is Array)
    {
        Array arr = (Array)value;
        arr.SetValue(myValue, myIndex);
    }
    else
    {
        ...
    }
