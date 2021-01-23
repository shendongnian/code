    interface ISchemaField<T>
    {
        string Name { get; }
    }
    interface ITableField<T> : ISchemaField<T>
    {
        int Index { get; }
    }
    interface IRecordField<T> : ITableField<T>
    {
        T Value { get; set; }
    }
