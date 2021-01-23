    MyClass<T,U> : IGenericInterface<T,U>
    {
      public T Convert(U param) { Console.WriteLine("U to T"); }
      public U Convert(T param) { Console.WriteLine("T to U"); }
    }
