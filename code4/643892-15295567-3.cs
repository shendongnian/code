    public void MyMethod(object source, string propertyName)
    {
        var pi = source.GetType().GetProperty(propertyName);
        if (pi == null)
        {
            throw new Exception("property not found");
        }
        MyMethod(source, pi);
    }
    public void MyMethod(object source, PropertyInfo property)
    {
        // Evaluate property
    }
    MyMethod(this, "Property");
