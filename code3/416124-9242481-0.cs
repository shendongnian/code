    public static class Extensions
    {
        public static void SendToMethod<T>(this IEnumerable<T> self, Delegate func  )
        {
            Contract.Requires(func.Method.GetParameters().Length == self.Count());
            func.DynamicInvoke(self.Cast<object>().ToArray());
        }
    }
