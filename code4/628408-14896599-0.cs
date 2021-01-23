    public class Foo3<T>
       where T : struct
    {
       private T _value;
       private T _nullValue;
       public Foo3(T initValue)
           : this(initValue, default(T))
       {
       }
       public Foo3(T initValue, T nullValue)
       {
          _value = initValue;
          _nullValue = nullValue;
       }
       public T Value { get { return _value; } }
        public bool IsNull
        {
            get 
            {
               return object.Equals(_value, _nullValue);
            }
        }
        public void Nullify() { _value = _nullValue; }
    }
