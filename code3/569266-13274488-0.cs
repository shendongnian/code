    public class SerializableEnvelope<T> : ISerializable
    {
        private T item;
        public T Item
        {
            get { return item; }
        }
        public SerializableEnvelope(T _item)
        {
            item = _item;
        }
        public SerializableEnvelope(SerializationInfo info, StreamingContext context)
        {
            item = Activator.CreateInstance<T>();
            FieldInfo[] fields = typeof(T).GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (FieldInfo field in fields)
                field.SetValue(item, info.GetValue(field.Name, field.FieldType));
        }
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            FieldInfo[] fields = typeof(T).GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (FieldInfo field in fields)
                info.AddValue(field.Name, field.GetValue(item));
        }
    }
