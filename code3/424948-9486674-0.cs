    using System.Linq;
    public static class Utility
    {
        public static bool EnsureValuesNotEmpty(params string[] values)
        {
            return values.All(value => !string.IsNullOrWhiteSpace(value));
        }
    }
