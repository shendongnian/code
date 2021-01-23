    object[] titleAttributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), true);
    if (titleAttributes.Length > 0 && titleAttributes[0] is AssemblyTitleAttribute)
    {
        string assemblyTitle = (titleAttributes[0] as AssemblyTitleAttribute).Title;
        MessageBox.Show(assemblyTitle);
    }
