    public static class FieldExtensions
    {
        public static void SetPrivateField<T>(this T instance, string field, object value)
        {
            typeof(T).GetField(field, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                .SetValue(instance, value);
        }
    }
