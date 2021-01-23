    // Get the value for each member in the dynamic object
    foreach (string memberName in memberNames)
    {
        //replace this line
        //values[memberName] = DynamicHelper.GetMemberValue(obj, memberName);
        
        //with this code
        var value = DynamicHelper.GetMemberValue(obj, memberName);
        if (value is DynamicJsonArray)
            value = (object[])(DynamicJsonArray)value;
        values[memberName] = value;
    }
