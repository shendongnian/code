    foreach(var propInfo in o.GetType().GetProperties())
    {
        var dmAttr = propInfo.GetCustomAttributes(typeof(DataMemberAttribute), false).FirstOrDefault();
        if (dmAttr == null)
            continue;
        object propValue = propInfo.GetValue(o, null);
        if (dmAttr.IsRequired && propValue == null)
            // It is required but does not have a value... do something about it here
    }
