    foreach (var propertyInfo in typeof(YOUR CLASS).GetProperties())
    {
        var attr = propertyInfo.GetCustomAttributesData();
        
        foreach (var customAttributeData in attr)
        {
            foreach (var item in customAttributeData.NamedArguments)
            {
                var name = item.MemberInfo.Name;
                var value = item.TypedValue.Value;
            }
        }
    }
