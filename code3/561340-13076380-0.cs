    using System.ComponentModel;
    using System.Reflection;
    
    public static class Program
    {
        static void Main()
        {
            PropertyInfo prop = typeof(Foo).GetProperty("Bar");
            var val = GetPropertyAttributes(prop, "DisplayName");
        }
        public static object GetPropertyAttributes(PropertyInfo prop, string attributeName)
        {
            // look for an attribute that takes one constructor argument
            foreach(CustomAttributeData attribData in prop.GetCustomAttributesData()) 
            {
                string typeName = attribData.Constructor.DeclaringType.Name;
                if(attribData.ConstructorArguments.Count == 1 &&
                    (typeName == attributeName || typeName == attributeName + "Attribute"))
                {
                    return attribData.ConstructorArguments[0].Value;
                }
            }
            return null;
        }
    }
    
    class Foo
    {
        [DisplayName("abc")]
        public string Bar { get; set; }
    }
