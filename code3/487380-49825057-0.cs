    public class CustomComparer<T> : IEqualityComparer<T>
    {
        public bool Equals(T expected, T actual)
        {
            var props = typeof(T).GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);
            foreach (var prop in props)
            {
                var expectedValue = prop.GetValue(expected, null);
                var actualValue = prop.GetValue(actual, null);
                if (expectedValue != actualValue)
                {
                    throw new EqualException($"A value of \"{expectedValue}\" for property \"{prop.Name}\"",
                        $"A value of \"{actualValue}\" for property \"{prop.Name}\"");
                }
            }
            return true;
        }
        public int GetHashCode(T parameterValue)
        {
            return Tuple.Create(parameterValue).GetHashCode();
        }
    }
