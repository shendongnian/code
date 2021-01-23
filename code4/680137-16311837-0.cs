    Dictionary<string, Type> types = new Dictionary<string, Type>();
    types.Add("DropDownList", typeof(DropDownList));
    ...
    
    private void InitialiseListControl(string controlType)
    {
        if (types.ContainsKey(controlType))
        {
            ListControl = (ListControl)Activator.CreateInstance(types[controlType]);
        }
        else
        {
            throw new ArgumentOutOfRangeException("controlType", controlType, "Invalid ListControl type specified.");
        }
    }
