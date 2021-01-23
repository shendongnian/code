    public class ItemField<T> where T :  ICloneable, IConvertible, IComparable<string>, IEnumerable<char>, IEnumerable, IEquatable<string>
    {
        public string FieldName { get; set; }
        public T FieldValue { get; set; }
    }
