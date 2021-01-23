    ActivityAssemblyAttribute attribute = null;
    object[] attributes = assembly.GetCustomAttributes(typeof(ActivityAssemblyAttribute), false);
    if (attributes.Length > 0)
    {
       attribute = attributes[0] as ActivityAssemblyAttribute;
    }
