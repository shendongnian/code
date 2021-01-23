    public static bool ValidateLoopAttributes<T>(string value, T threshold)
        where T : IComparable
    {
        try
        {
            var parseMethod = typeof(T).GetMethod("Parse", new[] {typeof (string)});
            var result = (T) parseMethod.Invoke(null, new object[] {value});
            return result.CompareTo(threshold) < 0;
        }
        catch (Exception)
        {
            return false;
        }
    }
