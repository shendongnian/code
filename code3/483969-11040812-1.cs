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
    class MyEntity : IEntity<int, string>
    {
        int IEntity<int, string>.Key
        {
            get { ... }
            set { ... }
        }
        string IEntity<int, string>.Value
        {
            get { ... }
            set { ... }
        }
        object IEntity.Key
        {
            get { ... }
            set { ... }
        }
        object IEntity.Value
        {
            get { ... }
            set { ... }
        }
    }
