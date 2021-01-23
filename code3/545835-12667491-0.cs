    void MyShinyAttributeFunction(Type type, ref List<string> propertyNames, ref List<string> basePropertyNames)
    {
        if (type == null)
            return;
    
        MyShinyAttributeFunction(type.BaseType, ref propertyNames, ref basePropertyNames);
    
        foreach (var property in type.GetProperties())
        {
            foreach (object customAttr in property.GetCustomAttributes(false))
            {
                if (customAttr is DataMemberAttribute)
                {
                    if (type.BaseType.Name.Equals("Object"))
                    {
                        DataMemberAttribute attribute = (DataMemberAttribute)customAttr;
                        if (!basePropertyNames.Contains(property.Name))
                            basePropertyNames.Add(property.Name);
                    }
                    else
                    {
                        DataMemberAttribute attribute = (DataMemberAttribute)customAttr;
                        if (!propertyNames.Contains(property.Name) && !basePropertyNames.Contains(property.Name))
                            propertyNames.Add(property.Name);
                    }
                }
            }
        }
    }
