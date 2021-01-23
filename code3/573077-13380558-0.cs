    public XElement Serialize(object source, 
                              string objectName, 
                              bool includeNonPublicProperties)
    {
        XElement element;
        var flags = BindingFlags.Instance | BindingFlags.Public;
        if(includeNonPublicProperties) 
        {
            flags |= BindingFlags.NonPublic;
        }
        var props = source.GetType().GetProperties(flags);
        var type = source.GetType();
        string nodeName;
        if(objectName == null)
        {
            if (type.IsGenericType)
            {
                nodeName = type.Name.CropAtLast('`');
            }
            else
            {
                nodeName = type.Name;
            }            
        }
        else
        {
            nodeName = objectName;
        }
        element = new XElement(nodeName);
        foreach (var prop in props)
        {
            string name = prop.Name;
            string value = null;
            bool valIsElement = false;
            if (!prop.CanRead) continue;
            if(prop.PropertyType.IsEnum)
            {
                value = prop.GetValue(source, null).ToString();
            }
            else 
            {
                string typeName;
                if (prop.PropertyType.IsNullable())
                {
                    typeName = prop.PropertyType.GetGenericArguments()[0].Name;
                }
                else
                {
                    typeName = prop.PropertyType.Name;
                }
                switch (typeName)
                {
                    case "String":
                    case "Boolean":
                    case "Byte":
                    case "TimeSpan":
                    case "Single":
                    case "Double":
                    case "Int16":
                    case "UInt16":
                    case "Int32":
                    case "UInt32":
                    case "Int64":
                    case "UInt64":
                        value = (prop.GetValue(source, null) ?? string.Empty).ToString();
                        break;
                    case "DateTime":
                        try
                        {
                            var tempDT = Convert.ToDateTime(prop.GetValue(source, null));
                            if (tempDT == DateTime.MinValue) continue;
                            value = tempDT.ToString("MM/dd/yyyy HH:mm:ss.fffffff");
                        }
                        catch(Exception ex)
                        {
                            continue;
                        }
                        break;
                    default:
                        var o = prop.GetValue(source, null);
                        XElement child;
                        if (o == null)
                        {
                            child = new XElement(prop.Name);
                        }
                        else
                        {
                            child = Serialize(o, prop.Name, includeNonPublicProperties);
                        }
                        element.Add(child);
                        valIsElement = true;
                        break;
                }
            }
            if (!valIsElement)
            {
                element.AddAttribute(name, value);
            }
        }
        return element;
    }
