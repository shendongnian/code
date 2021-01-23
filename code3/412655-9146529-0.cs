    public static T ResolveOrUse<T, U>() where U : T
    {
        try
        {
            return container.Resolve<T>();
        }
        catch (ComponentNotFoundException)
        {
            try
            {
                U instance = (U)Activator.CreateInstance(typeof(U));
                return (T)instance;
            }
            catch(Exception ex)
            {
                throw new InvalidOperationException("IOC Couldn't instantiate a '" + typeof(U) + "' because: " + ex.Message);
            }
        }
    }
