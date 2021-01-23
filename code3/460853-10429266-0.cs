    public static class Extensions
    {
        public static void Get<T>(this IA a, Action<T[]> action, params Type[] types) where T : IB
        {
            foreach (var type in types)
            {
                var method = a.GetType().GetMethod("Get").MakeGenericMethod(type);
                var ts = (T[])method.Invoke(a, null);
                action(ts);
            }
        }
    }
