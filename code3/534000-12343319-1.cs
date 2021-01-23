    public static class Calculator<T> {
    
       public static readonly Func<T, T, T> Add;
       public static readonly Func<T, T, T> Pow;
    
       static Calculator() {
           var p1 = Expression.Parameter(typeof(T));
           var p2 = Expression.Parameter(typeof(T));
           var addLambda = Expression.Lambda<Func<T, T, T>>(Expression.Add(p1, p2), p1, p2);
           Add = addLambda.Compile();
           // looks like the only Pow method on Math works for doubles
           var powMethod = typeof(Math).GetMethod("Pow", BindingFlags.Static | BindingFlags.Public);
           var powLambda = Expression.Lambda<Func<T, T, T>>(
               Expression.Convert(
                   Expression.Call(
                       powMethod,
                       Expression.Convert(p1, typeof(double)),
                       Expression.Convert(p2, typeof(double)),
                   ),
                   typeof(T)
               ),
               p1,
               p2
           );
           Pow = powLambda.Compile();
       }
    }
    
    // and then in your class
    
    T a, b;
    var sum = Calculator<T>.Add(a, b);
