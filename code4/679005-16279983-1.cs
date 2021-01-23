    public class RootProperty<T>
    {
        private T _value;
        public virtual T Value
        {
            get { return _value; }
            set
            {
                if (Equals(value, _value)) return;
                _value = value;
            }
        }
        public static implicit operator T(RootProperty<T> p)
        {
            return p.Value;
        }
        public override string ToString()
        {
            return "[RootProperty<" + typeof(T).Name + ">] " + Value;
        }
    }
    public class InheritedProperty<T> : RootProperty<T>
    {
        private bool _override;
        public bool Override
        {
            get { return _override; }
            set
            {
                if (value.Equals(_override)) return;
                _override = value;
                //If we now override and we had no value before, copy the value that was previously inherited for convinience
                if (_override && (Value == null || Value.Equals(default(T))))
                    Value = Parent.Value;
            }
        }
        public RootProperty<T> Parent { get; private set; }
        public override T Value
        {
            get
            {
                if (Override)
                {
                    return base.Value;
                }
                if (Parent == null)
                    throw new Exception("Parent musn't be null");
                return Parent.Value;
            }
            set
            {
                Override = true;
                base.Value = value;
            }
        }
        public InheritedProperty(RootProperty<T> parent)
        {
            Parent = parent;
        }
        public override string ToString()
        {
            return "[InheritedProperty<" + typeof(T).Name + ">] " + Value;
        }
    }
