    public class GenericClass<T>
    {
        public Option<T> Find()
        {
            //return Option.Some(item) if found otherwise Option.None<T>()
        }
    }
    public static class Option
    {
        public static Option<T> None<T>()
        {
            return new Option<T>(default(T), false);
        }
        public static Option<T> Some<T>(T value)
        {
            return new Option<T>(value, true);
        }
    }
    public sealed class Option<T>
    {
        private readonly T m_Value;
        private readonly bool m_HasValue;
        public void Option(T value, bool hasValue)
        {
            m_Value = value;
            m_HasValue = hasValue;
        }
        public bool HasValue 
        {
            get { return m_HasValue; }
        }        
        public T Value 
        {
            get { return m_Value; }
        }
    }
