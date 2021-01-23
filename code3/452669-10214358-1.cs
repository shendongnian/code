    public class SafeValue<T>
    {
        public T Value {get; set;}
        public bool HasValue
        {
            get
            {
                if(typeof(T).IsClass)
                    return Value != null;
                else return true;
            }
        }
    }
