        Action<object, RequestCompletedEventArgs> a1 = RequestCompleted<X>;
        Action<object, RequestCompletedEventArgs> a2 = RequestCompleted<Y>;
        Action<object, RequestCompletedEventArgs> a3 = RequestCompleted<Y>;
        Console.WriteLine(a1.Method == a2.Method); // false
        Console.WriteLine(a3.Method == a2.Method); // true
