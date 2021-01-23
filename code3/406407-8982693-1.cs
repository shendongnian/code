    using System.Collections.Generic;
    public class Test<T>
    {
         public T Value
         {
             get { return _Value; }
             set
             {
                 if (!EqualityComparer<T>.Default.Equals(_Value, value))
                 {
                     _Value = value;
                 }
             }
         }
         private T _Value;
    }
