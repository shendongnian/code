    static void Main()
    {
      int[] arr1 = { 7, 9, 13, };
      Array arr2 = arr1;
      IEnumerable arr3 = arr1;  // non-generic IEnumerable
      foreach (var x in arr1)  // hold mouse over var keyword to see compile-time type
      {
        Overloaded(x);  // go to definition to see which overload is used
      }
      foreach (var x in arr2)  // hold mouse over var keyword to see compile-time type
      {
        Overloaded(x);  // go to definition to see which overload is used
      }
      foreach (var x in arr3)  // hold mouse over var keyword to see compile-time type
      {
        Overloaded(x);  // go to definition to see which overload is used
      }
    }
    static void Overloaded(int x)
    {
      Console.WriteLine("int!");
    }
    static void Overloaded(object x)
    {
      Console.WriteLine("object!");
    }
