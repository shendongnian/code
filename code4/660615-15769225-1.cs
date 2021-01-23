    public class FieldWrapper
    {
        private object obj;
        private FieldInfo field;
        public FieldWrapper(object obj, FieldInfo field)
        {
            this.obj = obj;
            this.field = field;
        }
        public object Value
        {
            get
            {
                return field.GetValue(obj);
            }
            set
            {
                field.SetValue(obj, value);
            }
        }
    }
