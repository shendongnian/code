       public static class AttributeSniff
    {
        public static string Attributes<T>(this object inputobject, string propertyname) where T : Attribute
        {
            //each attribute can have different internal properties
            //DisplayNameAttribute has  public virtual string DisplayName{get;}
            Type objtype = inputobject.GetType();
            PropertyInfo propertyInfo = objtype.GetProperty(propertyname);
            if (propertyInfo != null)
            {
                object[] customAttributes = propertyInfo.GetCustomAttributes(typeof(T), true);
                // take only publics and return first attribute
                if (propertyInfo.CanRead && customAttributes.Count() > 0)
                {
                    //get that first one for now
                    Type ourFirstAttribute = customAttributes[0].GetType();
                    //Assuming your attribute will have public field with its name
                    //DisplayNameAttribute will have DisplayName property
                    PropertyInfo defaultAttributeProperty = ourFirstAttribute.GetProperty(ourFirstAttribute.Name.Replace("Attribute",""));
                    if (defaultAttributeProperty != null)
                    {
                        object obj1Value = defaultAttributeProperty.GetValue(customAttributes[0], null);
                        if (obj1Value != null)
                        {
                            return obj1Value.ToString();
                        }
                    }
                }
            }
            return null;
        }
    }
