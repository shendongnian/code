    using System.Collections.Generic;
    public class Test<T>
    {
         public T Value
         {
             get { return _Value; }
             set
             {
                 if (!Comparer<T>.Equals(_Value, value))
                 {
                     _Value = value;
                 }
             }
         }
         private T _Value;
    }
