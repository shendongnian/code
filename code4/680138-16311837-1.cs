    private void InitialiseListControl(string controlType)
    {
        Type t = Type.GetType(controlType, false);
        if (t != null && typeof(ListControl).IsAssignableFrom(t))
        {
            ListControl = (ListControl)Activator.CreateInstance(t);
        }
        else
        {
            throw new ArgumentOutOfRangeException("controlType", controlType, "Invalid ListControl type specified.");
        }
    }
