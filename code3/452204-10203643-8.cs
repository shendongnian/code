     public static T GetAttribute<T>(this ICustomAttributeProvider assembly, bool inherit = false) 
     where T : Attribute 
     {
         return assembly
             .GetCustomAttributes(typeof(T), inherit)
             .OfType<T>()
             .FirstOrDefault();
    }
