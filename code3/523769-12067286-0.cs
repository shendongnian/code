    class GenericClass<T>
    {
       delegate void Print(T arg); // T is the same as T in the class
       delegate void Print2<T>(T arg); // T is unrelated to T in the class.
    }
