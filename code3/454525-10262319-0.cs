    public class MyClass<T>
    {
        public string Name { get; set; }
        public Unit Unit { get; set; }
        public T Value { get; set; }
    
        public virtual void ResetValue()
        {
            Value = default(T);
        }
        public override string ToString()
        {
            return Value.ToString();
        }
    }
