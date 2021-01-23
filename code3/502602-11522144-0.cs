    static class Guard
    {
        public static void AgainstNulls(object parameter, string name = null)
        {
            if (parameter == null) 
                throw new ArgumentNullException(name ?? "guarded argument was null");
        }
    }
    Guard.AgainstNulls(parameter, "parameter");
