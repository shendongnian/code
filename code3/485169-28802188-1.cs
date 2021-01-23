            var curType = thisProperty.PropertyType;
            // Get the underlying types 'Parse' method
            if (curType.IsGenericType && curType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                curType = Nullable.GetUnderlyingType(curType);
            }
            var parse = curType.GetMethods().SingleOrDefault(m =>
                m.Name == "Parse" &&
                m.GetParameters().Length == 1 &&
                m.GetParameters()[0].ParameterType == typeof(string));
            var value = parse != null ?
                parse.Invoke(thisProperty, new object[] { properties[thisProperty.Name].StringValue }) :
                      Convert.ChangeType(properties[thisProperty.Name].PropertyAsObject, thisProperty.PropertyType);
            thisProperty.SetValue(this, value);
