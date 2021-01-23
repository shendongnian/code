    public class DefaultableValue<T>
    {
        private T m_Value = default(T);
        public T Value
        {
            get
            {
                if (IsInvalidPredicate(m_Value))
                {
                    m_Value = IfDefaultValueFunc();
                }
                return m_Value;
            }
        }
        private Predicate<T> IsInvalidPredicate { get; set; }
        private Func<T> IfDefaultValueFunc { get; set; }
        public static implicit operator T(DefaultableValue<T> property)
        {
            return property.Value;
        }
        public DefaultableValue(Predicate<T> isInvalidPredicate,Func<T> ifDefaultFunc)
            : this(default(T), isInvalidPredicate, ifDefaultFunc)
        {
        }
        public DefaultableValue(T initValue, Predicate<T> isInvalidPredicate, Func<T> ifDefaultFunc)
        {
            this.m_Value = initValue;
            this.IsInvalidPredicate = isInvalidPredicate;
            this.IfDefaultValueFunc = ifDefaultFunc;
        }
    }
