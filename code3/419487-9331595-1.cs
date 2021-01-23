    var type1 = typeof(Func<>);
    type1.GetGenericArguments(); // [ typeof(TResult) ]
    var type2 = typeof(Func<string>);
    type2.GetGenericArguments(); // [ typeof(String) ]
    var type3 = typeof(Tuple<string, int, bool>);
    type3.GetGenericArguments(); // [ typeof(String), typeof(Int32), typeof(Boolean) ]
