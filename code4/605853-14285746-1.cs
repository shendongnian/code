    public static class FooExtensions
    {
        public static string Name(this Foo Value)
        {
            string rv = string.Empty;
            FieldInfo fieldInfo = Value.GetType().GetField(Value.ToString());
            if (fieldInfo != null)
            {
                object[] customAttributes = fieldInfo.GetCustomAttributes(typeof (BarAttribute), true);
                if(customAttributes.Length>0 && customAttributes[0]!=null)
                {
                    BarAttribute barAttribute = customAttributes[0] as BarAttribute;
                    if (barAttribute != null)
                    {
                        rv = barAttribute.Name;
                    }
                }
            }
            return rv;
        }
    }
