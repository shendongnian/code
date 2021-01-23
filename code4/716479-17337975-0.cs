    public static void ClearEntityCache(this IDataContext dataContext)
            {
                const BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
                var method = dataContext.GetType().GetMethod("ClearCache", flags);
                method.Invoke(dataContext, null);
            }
