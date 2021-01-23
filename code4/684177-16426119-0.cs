    using System.Reflection;
    private Type[] GetControllersInNamespace(Assembly assembly, string controllernamespace)
    {
        return assembly.GetTypes().Where(types => string.Equals(types.Namespace, controllernamespace, StringComparison.Ordinal)).ToArray();
    }
