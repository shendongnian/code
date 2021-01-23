    public interface IDataTypeConverterBase
    {}
    public interface IDataTypeConverter : IDataTypeConverterBase
    {}
    public interface IDataTypeConverter2 : IDataTypeConverterBase
    {}
    public static Y Convert<T, Y>(T itemToConvert)
        where T : IDataTypeConverterBase, new()
        where Y : IDataTypeConverterBase, new()
    {
    }
