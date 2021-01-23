    private static void LoadPlugins(FileInfo file)
    {
        try
        {
            Assembly assembly = Assembly.LoadFrom(file.FullName);
            foreach (Type type in assembly.GetTypes())
            {
                if (type.IsSubclassOf(typeof(Plugin)) && type.IsAbstract == false)
                {
                    Plugin b = type.InvokeMember(null,
                                                BindingFlags.CreateInstance,
                                                null, null, null) as Plugin;
                    plugins.Add(new PluginWrapper(b, file));
                    b.Register();
                }
            }
        }
        catch (ReflectionTypeLoadException ex)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Exception exSub in ex.LoaderExceptions)
            {
                sb.AppendLine(exSub.Message);
                if (exSub is FileNotFoundException)
                {
                    FileNotFoundException exFileNotFound = exSub as FileNotFoundException;
                    if (!string.IsNullOrEmpty(exFileNotFound.FusionLog))
                    {
                        sb.AppendLine("Fusion Log:");
                        sb.AppendLine(exFileNotFound.FusionLog);
                    }
                }
                sb.AppendLine();
            }
            string errorMessage = sb.ToString();
            Log.Error("Plugins Manager", errorMessage);
        }
    }
