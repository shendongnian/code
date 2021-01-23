    static Generics<T> Test<T> (T parameterToTest) {
        return new Generics<T>(parameterToTest);
    }
    static void Main()
    {
        Generics<Int32> anInt = Test<Int32>(4);
        Generics<String> aString = Test<String>("test");
    }
    
