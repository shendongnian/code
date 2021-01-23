    public static void Main() {
        Assembly assembly = Assembly.GetExecutingAssembly();
        var descriptionAttribute = assembly
            .GetCustomAttributes<AssemblyDescriptionAttribute>(inherit: false)
            .FirstOrDefault();
            
        if (descriptionAttribute != null) {
            Console.WriteLine(descriptionAttribute.Description);
        }
           
        Console.ReadKey();
    }
    public static IEnumerable<T> GetCustomAttributes<T>(this ICustomAttributeProvider provider, bool inherit) where T : Attribute {
        return provider.GetCustomAttributes(typeof(T), inherit).OfType<T>();
    }
