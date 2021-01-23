    public class DynamicField
    {
        public String fieldName { get; set; }
        private Type _type;
        public void SetFieldType<T>() where T:struct
        {
            this._type = typeof(T);
        }
        public Type GetFieldType()
        {
            return this._type;
        }
        public DynamicField(String fieldName, Type datatype)
        {
            this.fieldName = fieldName;
        }
    }
