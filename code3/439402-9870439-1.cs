    public static class AttributeExtensions
    {
        public static string GetMainName(this Class1 class1)
        {
            System.Attribute[] attrs = System.Attribute.GetCustomAttributes(class1.GetType());  // reflection
            foreach (System.Attribute attr in attrs)
            {
                if (attr is HandlerAttribute)
                {
                    string mainName = (attr as HandlerAttribute).MainName;
                    return mainName;
                }
            }
            throw new Exception("No MainName Attribute");
        }
    }
