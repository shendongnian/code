    var a = Assembly.GetExecutingAssembly().GetCustomAttributes(
        typeof(AssemblyInformationalVersionAttribute), true)
        .FirstOrDefault() as AssemblyInformationalVersionAttribute;
    Debug.WriteLine(string.Format("AssemblyInformationalVersion: {0}",
    a.InformationalVersion));
