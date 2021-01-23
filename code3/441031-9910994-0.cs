    public static bool IsTypeSerializable(this Type type) {
        Contract.Requires(type != null);
        return type.GetCustomAttributes(typeof(SerializableAttribute), true)
                   .Any();
    }
