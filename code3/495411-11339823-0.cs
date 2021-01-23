    public class Nothing<T> where T : class
    {
         public static implicit operator T(Nothing<T> nothing)
         {
              // your logic here
         }
    }
