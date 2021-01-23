    interface IEntity
    {
        object Key { get; set; }
        object Value { get; set; }
    }
    interface IEntity<TKey, TValue> : IEntity
    {
        TKey Key { get; set; }
        TValue Value { get; set; }
    }
