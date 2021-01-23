    public static MyClass Sum(this IEnumerable<MyClass> source)
    {
        var result = new MyClass(); // all data will be zeros
        foreach(var item in source)
           result = result + item;
        return result;
    }
