    foreach(var memberInfo in obj.GetType().GetMember(memberName))
    {
        if(memberInfo is FieldInfo)
        {
            ((FieldInfo)memberInfo).SetValue(obj, newValue);
        }
        else if(memberInfo is PropertyInfo)
        {
            ((PropertyInfo)memberInfo).SetValue(obj, newValue);
        }
        // etc ...
    }
