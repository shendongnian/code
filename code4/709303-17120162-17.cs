    class DynamicField<T>
    {
        public DynamicField(TypeBuilder builder, string name)
        {
            var field = builder.DefineField(name, typeof(T), FieldAttributes.Public);
        }
    }
