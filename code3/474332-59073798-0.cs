    [ExcludeFromCodeCoverage]
    public static class TestExtensionMethods
    {
        public static T GetFieldValue<T>(this object sut, string name)
        {
            var field = sut
                .GetType()
                .GetField(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            return (T)field?.GetValue(sut);
        }
        public static T GetPropertyValue<T>(this object sut, string name)
        {
            var field = sut
                .GetType()
                .GetProperty(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            return (T)field?.GetValue(sut);
        }
    }
