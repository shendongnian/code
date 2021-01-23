    public struct Option<T>
    {
        private T value;
        private readonly bool hasValue;
        public bool IsSome => hasValue;
        public bool IsNone => !hasValue;
        public T Value
        {
            get
            {
                if (!hasValue) throw new NullReferenceException();
                return value;
            }
        }
        public static Option<T> None => new Option<T>();
        public static Option<T> Some(T value) => new Option<T>(value);
        private Option(T value)
        {
            this.value = value;
            hasValue = true;
        }
        public TResult Match<TResult>(Func<T, TResult> someFunc, Func<TResult> noneFunc) =>
            hasValue ? someFunc(value) : noneFunc();
        public override bool Equals(object obj)
        {
            if (obj is Option<T>)
            {
                var opt = (Option<T>)obj;
                return hasValue ? opt.IsSome && opt.Value.Equals(value) : opt.IsNone;
            }
            return false;
        }
        public override int GetHashCode() =>
            hasValue ? value.GetHashCode() : 0;
    }
