    public static class MyExtensions
    {
        public static T GetTypedVal<T>(this HttpSessionState session, string key)
        {
            var value = session[key];
            if (value != null)
            {
                if (value is T)
                {
                    return (T)value;
                }
            }
            throw new InvalidOperationException(
                         string.Format("Key {0} is not found in SessionState", key));
        }
    }
