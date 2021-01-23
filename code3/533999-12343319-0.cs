    public static class Calculator<T> {
    
       public static readonly Func<T, T, T> Add;
    
       static Calculator() {
           var p1 = Expression.Parameter(typeof(T));
           var p2 = Expression.Parameter(typeof(T));
           var addLambda = Expression.Lambda<Func<T, T, T>>(Expression.Add(p1, p2), p1, p2);
           Add = addLambda.Compile();
       }
    }
    
    // and then in your class
    
    T a, b;
    var sum = Calculator<T>.Add(a, b);
