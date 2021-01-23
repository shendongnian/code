    public static class SafeExecutor
    {
        public static T Execute<T>(Func<T> operation)
        {
            try
            {
                return operation();
            }
            catch (Exception ex)
            {
                // Log Exception
            }
            return default(T);
        }
    }
    var data = SafeExecutor.Execute<string>(() =>
    {
        // do something
        return "result";
    });
