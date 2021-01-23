    public class WarnIfGetButUninitialized<T>
    {
        T _property;
        public T Value
        {
            get
            {
                if(_property == null)
                {
                    Console.WriteLine("Error: cannot fetch property before it has been initialized properly.\n");
                    return default(T);
                }
                return _property;
            }
            set { _property = value; }
        }
    }
