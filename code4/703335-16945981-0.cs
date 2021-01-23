    abstract class FieldBase
    {
        public readonly string Name;
        protected FieldBase(string name) { Name = name; }
    }
    sealed class Field<T> : FieldBase where T : struct
    {
        public Field(string name) : base(name) { }
        public T Value;
    }
