    var par = Expression.Parameter(typeof(string));
    Expression<Predicate<string>> expression3 = 
        Expression.Lambda<Predicate<string>>(
            Expression.AndAlso(
                Expression.Invoke(expression1, par), 
                Expression.Invoke(expression2, par)), 
            par);
    Predicate<string> method1 = expression3.Compile();
    Console.WriteLine(method1("aaa"));
    Console.WriteLine(method1("bbb"));
    Console.WriteLine(method1("aaabbb"));
