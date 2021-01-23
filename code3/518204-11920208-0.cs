    public static string GetValueUsingReflection(string propertyName)
        {
            var field = Type.GetType("Agenamespace" + "." + "Age").GetField(propertyName, BindingFlags.Public | BindingFlags.Static);
            var fieldValue = field != null ? (string)field.GetValue(null) : string.Empty;
            return fieldValue;
        }
