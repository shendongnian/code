        public static class ResourceHelper
    {
        public static Stream GetEmbeddedResource(string physicalPath, string resourceName)
        {
            try
            {
                Assembly assembly = PluginHelper.LoadPluginByPathName<Assembly>(physicalPath);
                if (assembly != null)
                {
                    string tempResourceName = assembly.GetManifestResourceNames().ToList().FirstOrDefault(f => f.EndsWith(resourceName));
                    if (tempResourceName == null)
                        return null;
                    return assembly.GetManifestResourceStream(tempResourceName);
                }
            }
            catch (Exception)
            {
            }
            return null;
        }
    }
