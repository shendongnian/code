    public class DynamicField
    {
        public String fieldName { get; set; }
        private Type _type;
        public DynamicField SetFieldType<T>() where T:struct
        {
            this._type = typeof(T);
            return this;
        }
        public Type GetFieldType()
        {
            return this._type;
        }
        public DynamicField(String fieldName)
        {
            this.fieldName = fieldName;
        }
    }
