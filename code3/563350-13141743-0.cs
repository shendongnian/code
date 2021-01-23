    public class ValueModel<T> : IComparable
    {
        private object _value;
        private object _originalValue;
    
        public T Value
        {
            get { return (T)_value; }
            set
            {
                if ((object)value != _value)
                {
                    _value = value;
                }
            }
        }
    
        public ValueModel(T value)
        {
            _value = value;
            _originalValue = value;
        }
    
        public void AcceptChanges()
        {
            _originalValue = _value;
        }
    
        public void UndoChanges()
        {
            Value = (T)_originalValue;
        }
    
        // Muss implementiert werden, damit die Sortierung im CollectionView funktioniert.
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            if (object.ReferenceEquals(this, obj)) return 0;
            ValueModel<T> other = obj as ValueModel<T>;
            if (typeof(T) == typeof(String))
                return string.Compare(this._value.ToString(), other._value.ToString());
            else
                return ((IComparable)_value).CompareTo(other._value);
        }
    }
