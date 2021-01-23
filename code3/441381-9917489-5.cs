    public static bool IsImplementationOf(this Type checkMe, params Type[] forUs)
    {
        return forUs.Any(forMe =>
        {
            if (forMe.IsGenericTypeDefinition)
                return checkMe.GetInterfaces().Select(i =>
                {
                    if (i.IsGenericType)
                        return i.GetGenericTypeDefinition();
                    return i;
                }).Any(i => i == forMe);
            return forMe.IsAssignableFrom(checkMe);
        });
    }
