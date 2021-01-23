        public class Test<T> where T : class
        {
         public T Value
         {
             private T _Value;
             
             get { return _Value; }
             set
             {
                 if (_value != value)
                     _Value = value;             
             }
         }
    }
