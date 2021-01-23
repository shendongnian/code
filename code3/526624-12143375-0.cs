     var assemblyName = "System"; // assembly to get the guid
     var assembly = AppDomain.CurrentDomain
            .GetAssemblies()
            .FirstOrDefault(a => a.GetName().Name == assemblyName);
     var attr = assembly
            .GetCustomAttributes(false)
            .OfType<GuidAttribute>()
            .FirstOrDefault();
     var guid = attr.Value;
