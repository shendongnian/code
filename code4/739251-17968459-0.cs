    public interface IStringToTypeConverter<T> : IStringToTypeConverterUntyped
    {
        T FromString(string value);
        string ToString(T value);
    }
    public interface IStringToTypeConverterUntyped
    {
        object FromStringUntyped(string value);
        string ToString(object value);
    }
